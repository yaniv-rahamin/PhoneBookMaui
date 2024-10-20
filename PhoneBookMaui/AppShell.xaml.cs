using PhoneBookMaui.view;

namespace PhoneBookMaui
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute("/EditUser",typeof(EditUserPage));
        }
    }
}
