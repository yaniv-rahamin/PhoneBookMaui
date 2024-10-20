using PhoneBookMaui.model;
using PhoneBookMaui.view;
using System.Text.Json;

namespace PhoneBookMaui
{
    public partial class App : Application
    {
        //public static User? user;

        public App()
        {
            InitializeComponent();
            MainPage = new AppShell();
            //if(Preferences.Default.ContainsKey("userObj"))
            //{
            //    string json = Preferences.Default.Get<string>("UserObj",null);
            //    user = JsonSerializer.Deserialize<User>(json);
            //}
            //if (user != null)
            //{
            //    Shell.Current.GoToAsync("//ListUser");
            //}
            //else 
            //{
            //    Shell.Current.GoToAsync("Login");
            //}
                 
        }

         
    }
}
