using PhoneBookMaui.model;
using PhoneBookMaui.view;
using System.Text.Json;

namespace PhoneBookMaui
{
    public partial class App : Application
    {
        public static User? user;
        IServiceProvider provider;

        public App(IServiceProvider serviceProvider)
        {
            InitializeComponent();
            provider = serviceProvider; 
            MainPage = new AppShell();
            if (Preferences.Default.ContainsKey("userObj"))
            {
                string json = Preferences.Default.Get<string>("userObj", null);
                user = JsonSerializer.Deserialize<User>(json);
            }
            if (user != null)
            {
                Shell.Current.GoToAsync("//ListUser");
            }
            else
            {
                Page login = provider.GetService<LogINPage>();
                Shell.Current.Navigation.PushModalAsync(login);
            }

        }

         
    }
}
