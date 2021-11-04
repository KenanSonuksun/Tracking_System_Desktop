using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FireSharp.Config;
using FireSharp.Response;
using FireSharp.Interfaces;

namespace TrackingSystem
{
    public partial class Register : Form
    {
        //firestore settings
        IFirebaseConfig ifc = new FirebaseConfig()
        {
            AuthSecret = "FIREBASE AUTH SECRET",
            BasePath = "FIREBASE BASE PATH WITH .json"
        };
        IFirebaseClient client;

        //to save that user is customer or not (for combobox) 
        private string selectedItem;
        private bool state;
        public Register()
        {
            InitializeComponent();
        }
        private void Register_Load(object sender, EventArgs e)
        {
            //to assign the chocies to combo box
            comboBox1.Items.Add("Müşteri");
            comboBox1.Items.Add("Kargocu");
            //to check internet connection
            try
            {
                client = new FireSharp.FirebaseClient(ifc);
            }

            catch
            {
                MessageBox.Show("No Internet or Connection Problem");
            }
        }
        private void registerButton_Click(object sender, EventArgs e)
        {
            //to check conditions
            #region Condition
            if (string.IsNullOrWhiteSpace(userNameRegister.Text) &&
               string.IsNullOrWhiteSpace(userPasswordRegister.Text) &&

               string.IsNullOrWhiteSpace(userNameRegister.Text) &&
               string.IsNullOrWhiteSpace(userPasswordRegister.Text))
            {
                MessageBox.Show("Please Fill All The Fields");
                return;
            }
            #endregion

            //to push Firestore
            UsersInfo user = new UsersInfo()
            {
                Username = userNameRegister.Text,
                Password = userPasswordRegister.Text,
            };
            SetResponse set = client.Set("Users/" + userNameRegister.Text, user);
            SetResponse setState = client.Set("Users/" + userNameRegister.Text + "/state", state);
            //dialog
            MessageBox.Show("Successfully registered!");

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //to assign a bollean value to state by selected item
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
