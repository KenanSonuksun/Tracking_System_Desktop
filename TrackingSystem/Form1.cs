using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Google.Cloud.Firestore;
using FireSharp.Config;
using FireSharp.Response;
using FireSharp.Interfaces;

namespace TrackingSystem
{
    public partial class Form1 : Form
    {
        //firestore settings
        IFirebaseConfig ifc = new FirebaseConfig()
        {
            AuthSecret = "E7U4GeB4XUjYcNndOaSp0OAXr1Wh3agyvOuYX8rp",
            BasePath = "https://kargosistemi-default-rtdb.firebaseio.com/"
        };
        IFirebaseClient client;
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                client = new FireSharp.FirebaseClient(ifc);
            }

            catch
            {
                MessageBox.Show("No Internet or Connection Problem");
            }
           
        }
        //SigninButton Click
        private void SignInButton_Click(object sender, EventArgs e)
        {
            #region Condition
            if (string.IsNullOrWhiteSpace(userNameSignIn.Text) &&
               string.IsNullOrWhiteSpace(userPasswordSignIn.Text))
            {
                MessageBox.Show("Please Fill All The Fields");
                return;
            }
            #endregion

            FirebaseResponse res = client.Get("Users/"+ userNameSignIn.Text);
            UsersInfo ResUser = res.ResultAs<UsersInfo>();

            UsersInfo CurUser = new UsersInfo()
            {
                Username = userNameSignIn.Text,
                Password = userPasswordSignIn.Text
            };

            if (UsersInfo.IsEqual(ResUser, CurUser))
            {
                User.UserName = userNameSignIn.Text;
                User.Password = userPasswordSignIn.Text;
                Global.State = ResUser.State;
                HomePage real = new HomePage();
                real.ShowDialog();
            }

            else
            {
                UsersInfo.ShowError();
            }

        }

        private void goToRegister_Click(object sender, EventArgs e)
        {
            Register register = new Register();
            register.Show();
        }

       
    }
}
