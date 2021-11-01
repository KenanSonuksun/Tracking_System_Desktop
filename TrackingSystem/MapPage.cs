using GMap.NET;
using GMap.NET.MapProviders;
using GMap.NET.WindowsForms;
using GMap.NET.WindowsForms.Markers;
using Google.Cloud.Firestore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace TrackingSystem
{
    public partial class MapPage : Form
    {
        public MapPage()
        {
            InitializeComponent();

        }
        private void MapPage_Load(object sender, EventArgs e)
        {
            //Gmap Settings
            GMaps.Instance.Mode = AccessMode.ServerAndCache;
            googleMap.CacheLocation = @"cache";
            googleMap.SetPositionByKeywords("Türkiye,izmit");
            googleMap.DragButton = MouseButtons.Left;
            googleMap.MapProvider = GMapProviders.GoogleMap;
            googleMap.ShowCenter = false;
            googleMap.MinZoom = 1;
            googleMap.MaxZoom = 100;
            googleMap.Zoom = 10;
            //timer settings
            System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();
            timer.Interval = (5 * 1000); // 5 secs
            timer.Tick += new EventHandler(timer_Tick);
            timer.Start();
        }
        private void timer_Tick(object sender, EventArgs e)
        {
            //to refresh the app
            this.Controls.Clear();
            this.InitializeComponent();
            routeFunction();
        }
        void routeFunction()
        {
            //gmap settings
            GMapProviders.GoogleMap.ApiKey = ApiKey.Key;
            googleMap.DragButton = MouseButtons.Left;
            googleMap.MapProvider = GMapProviders.GoogleMap;
            googleMap.MinZoom = 1;
            googleMap.MaxZoom = 100;
            googleMap.Zoom = 10;
            //all process
            for (int i = 0; i < Global.globalPoints.Count; i++)
            {
                //for first marker
                if(i== 0)
                {
                    double lat = Convert.ToDouble(Global.globalPoints[Convert.ToInt32(Global.totalArray[Global.index, i])].Lat);
                    double lng = Convert.ToDouble(Global.globalPoints[Convert.ToInt32(Global.totalArray[Global.index, i])].Lng);
                    googleMap.Position = new PointLatLng(lat, lng);
                    PointLatLng point = new PointLatLng(lat, lng);
                    GMapMarker marker = new GMarkerGoogle(point, GMarkerGoogleType.green_dot);
                    //to create a overly
                    GMapOverlay markers = new GMapOverlay("markers");
                    //to add all markers to the overly
                    markers.Markers.Add(marker);
                    //to show on google maps
                    googleMap.Overlays.Add(markers);
                }
                //for other markers
                else
                {
                    double lat = Convert.ToDouble(Global.globalPoints[Convert.ToInt32(Global.totalArray[Global.index, i])].Lat);
                    double lng = Convert.ToDouble(Global.globalPoints[Convert.ToInt32(Global.totalArray[Global.index, i])].Lng);
                    googleMap.Position = new PointLatLng(lat, lng);
                    PointLatLng point = new PointLatLng(lat, lng);
                    GMapMarker marker = new GMarkerGoogle(point, GMarkerGoogleType.red_dot);
                    //to create a overly
                    GMapOverlay markers = new GMapOverlay("markers");
                    //to add all markers to the overly
                    markers.Markers.Add(marker);
                    //to show on google maps
                    googleMap.Overlays.Add(markers);
                }
                //to draw route between points
                if (i + 1 < Global.globalPoints.Count)
                {
                    Console.WriteLine(Convert.ToInt32(Global.totalArray[Global.index, i]).ToString() + Convert.ToInt32(Global.totalArray[Global.index, i + 1]).ToString());
                    Console.Read();
                    var route = GoogleMapProvider.Instance.GetRoute(Global.globalPoints[Convert.ToInt32(Global.totalArray[Global.index, i])], Global.globalPoints[Convert.ToInt32(Global.totalArray[Global.index, i + 1])], false, false, 14);
                    var r = new GMapRoute(route.Points, "My Route")
                    {
                        Stroke = new Pen(Color.Red, 5)
                    };
                    var routes = new GMapOverlay("routes");
                    routes.Routes.Add(r);
                    googleMap.Overlays.Add(routes);

                }

            }

        }
        private void googleMap_Load(object sender, EventArgs e)
        {
        }
    }
}
