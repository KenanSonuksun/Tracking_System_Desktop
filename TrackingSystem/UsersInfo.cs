namespace TrackingSystem
{
    class UsersInfo
    {
        //to save user name
        public string Username { get; set; }
        //to save password
        public string Password { get; set; }
        //to check that user is costumer or not
        public bool State { get; set; }
        //error text
        private static string error = "Username does not exist!";
        //to show error dialog
        public static void ShowError()
        {
            System.Windows.Forms.MessageBox.Show(error);
        }

        //to check password and user name by database
        public static bool IsEqual(UsersInfo user1, UsersInfo user2)
        {
            if (user1 == null || user2 == null) { return false; }

            if (user1.Username != user2.Username)
            {
                error = "Username does not exist!";
                return false;
            }

            else if (user1.Password != user2.Password)
            {
                error = "Username and password does not match!";
                return false;
            }

            return true;
        }
    }
}
