using PhoneBookMaui.view;
using System.Windows.Input;
using PhoneBookMaui.model;

namespace PhoneBookMaui
{
    public partial class AppShell : Shell
    {

        public static User? user;
        public ICommand LogoutCommand =>
             new Command(async () => {
                 App.user = null;
                 if (Preferences.Default.ContainsKey("userObj"))
                     Preferences.Default.Remove("userObj");
                 await Shell.Current.DisplayAlert("Goodbye", "שלום", "אישור");

                 await Shell.Current.GoToAsync("Login");
                 Shell.Current.FlyoutIsPresented = false;

             });

        public AppShell()
        {
            InitializeComponent();
            this.BindingContext = this;
            Routing.RegisterRoute("/EditUser",typeof(EditUserPage));
            Routing.RegisterRoute("Login", typeof(LogINPage));
            Routing.RegisterRoute("RegisterPage", typeof(SignInPage));

        }
    }
}
