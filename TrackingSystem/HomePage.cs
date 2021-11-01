using GMap.NET;
using GMap.NET.MapProviders;
using GMap.NET.WindowsForms;
using GMap.NET.WindowsForms.Markers;
using Google.Cloud.Firestore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using FireSharp.Config;
using FireSharp.Response;
using FireSharp.Interfaces;
using Newtonsoft.Json;
using System.IO;
using System.Net;
using System.Threading;

namespace TrackingSystem
{
    public partial class HomePage : Form
    {
        private string[,] totalArray = new string[100, 100];
        private double[,] totalKmArray = new double[100, 100];
        private string[,] globalArray = new string[100, 100];

        //to save that user is customer or not (for combobox) 
        private string selectedItem;
        private bool state;
        //firestore settings
        IFirebaseConfig ifc = new FirebaseConfig()
        {
            AuthSecret = "E7U4GeB4XUjYcNndOaSp0OAXr1Wh3agyvOuYX8rp",
            BasePath = "https://kargosistemi-default-rtdb.firebaseio.com/"
        };
        IFirebaseClient client;

        public HomePage()
        {

            InitializeComponent();
            try
            {
                client = new FireSharp.FirebaseClient(ifc);
            }
            catch
            {
                MessageBox.Show("No Internet or Connection Problem");
            }
            //Thread
            Thread mainThread = Thread.CurrentThread;
            mainThread.Name = "thread";
            SetListener();
            //if user is a customer , hide some tools
            if (Global.State)
            {
                listBox1.Hide();
                goToMapButton.Hide();
                moveButton.Hide();
                label4.Hide();
            }
        }

        //to manage other forms with thread
        private EventStreamResponse listener;
        async void SetListener()
        {
            listener = await client.OnAsync("coordinates",
                     added: (sender, args, context) => { GetCoordinates(); },
                     changed: (sender, args, context) => { GetCoordinates(); },
                     removed: (sender, args, context) => { GetCoordinates(); });
        }


        private void HomePage_Load(object sender, EventArgs e)
        {
            //to show username userpassword and userstate at first step
            comboBox1.Items.Add("Müşteri");
            comboBox1.Items.Add("Kargocu");
            updateUserNameText.Text = User.UserName;
            updatePasswordText.Text = User.Password;
            if (Global.State)
            {
                comboBox1.SelectedIndex = 0;
            }
            else
            {
                comboBox1.SelectedIndex = 1;
            }
            //gmap settings
            googleMap.ShowCenter = false;
            GMaps.Instance.Mode = AccessMode.ServerAndCache;
            googleMap.CacheLocation = @"cache";
            googleMap.SetPositionByKeywords("Türkiye,izmit");
            googleMap.DragButton = MouseButtons.Left;
            googleMap.MapProvider = GMapProviders.GoogleMap;
            googleMap.MinZoom = 5;
            googleMap.MaxZoom = 100;
            googleMap.Zoom = 7;
            //timer settings
            System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();
            timer.Interval = (2 * 1000); // 5 secs
            timer.Tick += new EventHandler(this.Timer);
            timer.Start();
        }
        private void Timer(object sender, EventArgs e)
        {
            //to back the default settings
            CoordinatesList.list.Clear();
            Global.count = 0;
            Global.globalPoints.Clear();
            Global.index = 0;
            Global.numberOfElement = 0;
            Array.Clear(Global.totalArray, 0, Global.totalArray.Length);
            Array.Clear(totalArray, 0, totalArray.Length);
            Array.Clear(totalKmArray, 0, totalKmArray.Length);
            Array.Clear(globalArray, 0, globalArray.Length);
            listBox1.Items.Clear();
            GetCoordinates();
        }
        void PostFirebase(string lat, string lng)
        {
            string address = "https://kargosistemi-default-rtdb.firebaseio.com/.json";
            WebRequest request = HttpWebRequest.Create(address);
            WebResponse webRes;
            webRes = request.GetResponse();

            StreamReader streamReader = new StreamReader(webRes.GetResponseStream());
            string getInfos = streamReader.ReadToEnd();

            Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(getInfos);

            Dictionary<string, object> coordinates = new Dictionary<string, object>()
            {
                {"lat",lat},
                {"lng",lng }
            };

            Index.index = myDeserializedClass.Index;
            SetResponse set = client.Set("Coordinates/" + Index.index, coordinates);
            Index.index++;
            SetResponse setIndex = client.Set("Index", Index.index);


            MessageBox.Show("Successful");
        }

        public class Coordinate
        {
            public string lat { get; set; }
            public string lng { get; set; }
        }

        public class Root
        {
            public List<Coordinate> Coordinates { get; set; }
            public int Index { get; set; }
            public int Move { get; set; }
        }

        //to get coordinates and calculate the shortest way
        void GetCoordinates()
        {
            //firestore settings
            string address = "https://kargosistemi-default-rtdb.firebaseio.com/.json";
            WebRequest request = HttpWebRequest.Create(address);
            WebResponse webRes;
            webRes = request.GetResponse();
            StreamReader streamReader = new StreamReader(webRes.GetResponseStream());
            string getInfos = streamReader.ReadToEnd();
            Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(getInfos);

            if (myDeserializedClass.Coordinates != null)
            {
                //to assign all datas to another array
                for (int i = 0; i < myDeserializedClass.Coordinates.Count; i++)
                {
                    if (myDeserializedClass.Coordinates[i].lat != null && myDeserializedClass.Coordinates[i].lng != null)
                    {
                        CoordinatesList.list.Add(myDeserializedClass.Coordinates[i].lat);
                        CoordinatesList.list.Add(myDeserializedClass.Coordinates[i].lng);
                    }
                }
                //to add the global points from Global Class
                for (int i = 0; i < CoordinatesList.list.Count; i = i + 2)
                {
                    if (CoordinatesList.list[i] != null)
                    {
                        Global.globalPoints.Add(new PointLatLng(Convert.ToDouble(CoordinatesList.list[i]), Convert.ToDouble(CoordinatesList.list[i + 1])));
                    }
                }
                //to add all data to list box
                for (int i = 0; i < Global.globalPoints.Count; i++)
                {
                    listBox1.Items.Add(Global.globalPoints[i].Lat.ToString() + " - " + Global.globalPoints[i].Lng.ToString());
                }

                Global.numberOfElement = Global.globalPoints.Count - 1;
                int[] arr = new int[Global.numberOfElement];
                //to assign datas from the mystreio
                for (int i = 0; i < Global.numberOfElement; i++)
                {
                    arr[i] = i + 1;
                }

                //if the points are less than 3
                if (myDeserializedClass.Index == 3)
                {
                    //shuffle the points just once is enough
                    //this area is about dijikstra algortihm(to find the shortest route between points)
                    Dijikstra(arr, 200);
                    for (int i = 0; i < Global.count; i++)
                    {
                        int[] tempArray = new int[Global.numberOfElement];
                        for (int j = 0; j < Global.numberOfElement; j++)
                        {
                            tempArray[j] = Convert.ToInt32(globalArray[i, j]);
                        }
                        tempArray = InsertFunction(tempArray, 0);
                        for (int a = 0; a < tempArray.Length; a++)
                        {
                            Global.totalArray[i, a] = tempArray[a].ToString();
                        }
                    }
                    //to calculate total distance and edges
                    Results();
                }
                //if the points are more than 3 
                else
                {
                    //this area is about dijikstra algortihm(to find the shortest route between points)
                    //if the points from the database are more than 3 you have to investigate all combinations to find the shortest route
                    //we have to shuffle the all points to find all combinations so;

                    //first step
                    Dijikstra(arr, 200);
                    //second step
                    for (int i = 0; i < Global.numberOfElement; i++)
                    {
                        int[] tempArray = new int[arr.Length];
                        for (int j = 0; j < Global.numberOfElement; j++)
                        {
                            tempArray[j] = Convert.ToInt32(globalArray[i, j]);

                        }
                        Dijikstra(tempArray, i);
                    }
                    //third step
                    for (int i = Global.numberOfElement; i < (Global.numberOfElement * Global.numberOfElement); i++)
                    {
                        int[] tempArray = new int[Global.numberOfElement];
                        for (int j = 0; j < Global.numberOfElement; j++)
                        {
                            tempArray[j] = Convert.ToInt32(globalArray[i, j]);

                        }
                        Dijikstra(tempArray, i);
                    }
                    //after shuffling we have to add 0 to start of the array because our first point points need to be 0
                    for (int i = 0; i < Global.count; i++)
                    {
                        int[] tempArray = new int[Global.numberOfElement];
                        for (int j = 0; j < Global.numberOfElement; j++)
                        {
                            tempArray[j] = Convert.ToInt32(globalArray[i, j]);
                        }
                        tempArray = InsertFunction(tempArray, 0);
                        for (int a = 0; a < tempArray.Length; a++)
                        {
                            Global.totalArray[i, a] = tempArray[a].ToString();
                        }
                    }
                    //to calculate distance
                    Results();
                }
            }


        }
        //to displacement between points
        void DisplacementFunction(int[] array, int[] valueArray)
        {
            //with this algorithm we can shuffle the array with a rule
            //the rule is to scroll once every each element to throgh right
            //and then we need to add elements that do not want to shuffle
            for (int j = 0; j < array.Length; j++)
            {
                //to scroll
                int temp = array[array.Length - 1];
                for (int i = array.Length - 1; i > 0; i--)
                {
                    array[i] = array[i - 1];

                }
                array[0] = temp;
                //to insert
                for (int i = valueArray.Length - 1; i >= 0; i--)
                {
                    array = InsertFunction(array, valueArray[i]);
                }
                //to save in global array
                for (int i = 0; i < array.Length; i++)
                {
                    globalArray[Global.count, i] = array[i].ToString();
                }
                //increasing count to save that how much points are there
                Global.count += 1;
                //to remove
                for (int i = 0; i < valueArray.Length; i++)
                {
                    array = RemoveElement(array);
                }
            }
        }
        //to displacement between points for the first step
        void DisplacementFunctionForTheFirstStep(int[] array)
        {
            //with the function can scroll elements once to right
            //and then we need to add the global array
            //we use the function at first step of dijkstra
            for (int j = 0; j < array.Length; j++)
            {
                int temp = array[array.Length - 1];
                for (int i = array.Length - 1; i > 0; i--)
                {
                    array[i] = array[i - 1];

                }
                array[0] = temp;
                for (int i = 0; i < array.Length; i++)
                {
                    globalArray[j, i] = array[i].ToString();

                }
                Global.count += 1;
            }
        }
        //to add 0 to start of the array
        int[] InsertFunction(int[] array, int value)
        {
            int[] tempArray = new int[array.Length + 1];
            int pos = 1;

            for (int i = 0; i < array.Length + 1; i++)
            {
                if (i < pos - 1)
                    tempArray[i] = array[i];
                else if (i == pos - 1)
                    tempArray[i] = value;
                else
                    tempArray[i] = array[i - 1];
            }

            return tempArray;
        }
        //to remove the first element from array
        int[] RemoveElement(int[] tempArray)
        {
            tempArray = tempArray.Where((source, index) => index != 0).ToArray();
            return tempArray;
        }
        //Dijikstra Algorithm
        void Dijikstra(int[] array, int index)
        {
            if (index != 200)
            {
                if (index < array.Length)
                {
                    int[] valueArray = new int[1];
                    for (int i = 0; i < valueArray.Length; i++)
                    {
                        valueArray[i] = array[i];
                    }
                    for (int i = 0; i < valueArray.Length; i++)
                    {
                        array = RemoveElement(array);
                    }
                    DisplacementFunction(array, valueArray);
                }
                else if (array.Length <= index && index < (array.Length * array.Length))
                {
                    int[] valueArray = new int[2];
                    for (int i = 0; i < valueArray.Length; i++)
                    {
                        valueArray[i] = array[i];
                    }
                    for (int i = 0; i < valueArray.Length; i++)
                    {
                        array = RemoveElement(array);
                    }
                    DisplacementFunction(array, valueArray);
                }

            }
            else if (index == 200)
            {
                DisplacementFunctionForTheFirstStep(array);
            }


        }
        //results
        void Results()
        {
            totalArray = Global.totalArray;
            //to find the shortest distance
            for (int i = 0; i < Global.count; i++)
            {
                double km = 0;
                for (int j = 0; j < Global.count; j++)
                {
                    km = km + CalculateDistance(Global.globalPoints[Convert.ToInt32(totalArray[i, j])], Global.globalPoints[Convert.ToInt32(totalArray[i, j + 1])]);
                }
                totalKmArray[i, 0] = km;
                totalKmArray[i, 1] = i;
            }
            double shortest = totalKmArray[0, 0];
            for (int i = 1; i < Global.count; i++)
            {
                if (totalKmArray[i, 0] < shortest)
                {
                    shortest = totalKmArray[i, 0];
                    Global.index = Convert.ToInt32(totalKmArray[i, 1]);
                }
            }
            Console.WriteLine("En kısa yol haritası;\n");
            for (int i = 0; i < Global.numberOfElement + 1; i++)
            {
                Console.WriteLine(totalArray[Global.index, i]);
            }
            Console.WriteLine("Toplam yol =>" + " " + shortest + "km");

        }
        //to calculate distance between 2 points
        int CalculateDistance(PointLatLng point1, PointLatLng point2)
        {

            var route = GoogleMapProvider.Instance.GetRoute(point1, point2, false, false, 14);
            var r = new GMapRoute(route.Points, "My Route");
            var routes = new GMapOverlay("routes");
            routes.Routes.Add(r);
            googleMap.Overlays.Add(routes);

            return Convert.ToInt32(route.Distance);
        }
        //to move the courier
        async void Move(PointLatLng point)
        {
            string address = "https://kargosistemi-default-rtdb.firebaseio.com/.json";
            WebRequest request = HttpWebRequest.Create(address);
            WebResponse webRes;
            webRes = request.GetResponse();

            StreamReader streamReader = new StreamReader(webRes.GetResponseStream());
            string getInfos = streamReader.ReadToEnd();

            Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(getInfos);
            List<Coordinate> x = new List<Coordinate>();
            int value = 0;
            PointLatLng latLng = point;
            //to find the next point that marker will need to go
            for (int i = 0; i < myDeserializedClass.Index; i++)
            {
                if (myDeserializedClass.Coordinates[i].lat.ToString() == latLng.Lat.ToString() && myDeserializedClass.Coordinates[i].lng.ToString() == latLng.Lng.ToString())
                {
                    value = i;
                }
            }
            //after finding remove the previous point from the database
            for (int i = 0; i < myDeserializedClass.Index; i++)
            {
                x.Add(myDeserializedClass.Coordinates[i]);
            }
            x.RemoveAt(value);
            for (int i = 0; i < myDeserializedClass.Coordinates.Count - 1; i++)
            {
                Dictionary<string, object> coordinates = new Dictionary<string, object>()
                {
                    {"lat",x[i].lat},
                    {"lng",x[i].lng}
                };
                SetResponse setIndex = client.Set("Coordinates/" + i, coordinates);
            }
            FirebaseResponse removeCoordinate = await client.DeleteAsync("Coordinates/" + (myDeserializedClass.Index - 1).ToString());
            SetResponse setIndex2 = client.Set("Index", (myDeserializedClass.Index - 1));
        }
        private List<String> GetAddress(PointLatLng point)
        {
            List<Placemark> placemarks = null;
            var statusCode = GMapProviders.GoogleMap.GetPlacemarks(point, out placemarks);

            if (statusCode == GeoCoderStatusCode.OK && placemarks != null)
            {
                List<String> addresses = new List<string>();
                foreach (var placemark in placemarks)
                {
                    addresses.Add(placemark.Address);
                }
                return addresses;
            }
            return null;
        }
        private void LoadMap(PointLatLng point)
        {
            googleMap.Position = point;
        }
        private void findButton_Click(object sender, EventArgs e)
        {
            if (latText.Text != null && lngText.Text != null)
            {
                GMapProviders.GoogleMap.ApiKey = ApiKey.Key;
                googleMap.DragButton = MouseButtons.Left;
                googleMap.MapProvider = GMapProviders.GoogleMap;
                double lat = Convert.ToDouble(latText.Text);
                double lng = Convert.ToDouble(lngText.Text);
                googleMap.Position = new PointLatLng(lat, lng);


                PointLatLng point = new PointLatLng(lat, lng);
                GMapMarker marker = new GMarkerGoogle(point, GMarkerGoogleType.red_dot);
                //to create a overly
                GMapOverlay markers = new GMapOverlay("markers");
                //to add all markers to the overly
                markers.Markers.Add(marker);
                //to show on google maps
                googleMap.Overlays.Add(markers);

                googleMap.MaxZoom = 100;
                googleMap.MinZoom = 1;
                googleMap.Zoom = 10;
            }

        }

        private void addPointButton_Click(object sender, EventArgs e)
        {
            //GlobalArray.globalPoints.Add(new PointLatLng(Convert.ToDouble(latText.Text), Convert.ToDouble(lngText.Text)));
            PostFirebase(latText.Text, lngText.Text);

        }

        private void mapPageButton_Click(object sender, EventArgs e)
        {
            MapPage mapPage = new MapPage();
            mapPage.Show();
        }

        private void googleMap_Load(object sender, EventArgs e)
        {

        }

        private void googleMap_MouseClick(object sender, MouseEventArgs e)
        {
            //to select a point from google map as manuel
            if (e.Button == MouseButtons.Right)
            {
                var point = googleMap.FromLocalToLatLng(e.X, e.Y);
                double lat = point.Lat;
                double lng = point.Lng;

                latText.Text = lat + "";
                lngText.Text = lng + "";

                LoadMap(point);


                point = new PointLatLng(lat, lng);
                GMapMarker marker = new GMarkerGoogle(point, GMarkerGoogleType.red_dot);
                //to create a overly
                GMapOverlay markers = new GMapOverlay("markers");
                //to add all markers to the overly
                markers.Markers.Add(marker);
                //to show on google maps
                googleMap.Overlays.Add(markers);

                var addresses = GetAddress(point);
                if (addresses != null)
                    richTextBox1.Text = "Address:  \n--------------\n" + String.Join(",", addresses.ToArray());
                else
                    richTextBox1.Text = "Adres bulunmadı";
            }
        }

        private void moveButton_Click(object sender, EventArgs e)
        {
            //we have to back the default settings to refresh
            Move(Global.globalPoints[Convert.ToInt32(totalArray[Global.index, 0])]);
            CoordinatesList.list.Clear();
            Global.count = 0;
            Global.globalPoints.Clear();
            Global.index = 0;
            Global.numberOfElement = 0;
            Array.Clear(Global.totalArray, 0, Global.totalArray.Length);
            Array.Clear(totalArray, 0, totalArray.Length);
            Array.Clear(totalKmArray, 0, totalKmArray.Length);
            Array.Clear(globalArray, 0, globalArray.Length);
            listBox1.Items.Clear();
            GetCoordinates();
        }

        private void settingsButton_Click(object sender, EventArgs e)
        {

            UsersInfo user = new UsersInfo()
            {
                Username = updateUserNameText.Text,
                Password = updatePasswordText.Text,
                State = state,
            };
            var setter = client.Set("Users/" + updateUserNameText.Text, user);
            MessageBox.Show("Succesful");
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectedItem = this.comboBox1.GetItemText(this.comboBox1.SelectedItem);
            if (selectedItem == "Müşteri")
            {
                state = true;
            }
            else
            {
                state = false;
            }
        }
    }
}
