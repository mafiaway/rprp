namespace mw
{
    partial class Player
    {
        Connection con;
        string homepage = "http://www.mafiaway.nl/";
        
        public Player()
        {
            con = new Connection();
        }

        internal bool Login(string username, string password)
        {
            con.HttpPost(homepage + "login.php", "login=" + username + "&password=" + password);// + "&submit=Inloggen", true, "");
            string homeScreen = con.SimpleHttpGet(homepage);

            if (homeScreen.Contains("Hoofdkwartier")) 
                return true;
            else 
                return false;
        }

        internal bool Logout()
        {
            return false;
        }
    }
}
