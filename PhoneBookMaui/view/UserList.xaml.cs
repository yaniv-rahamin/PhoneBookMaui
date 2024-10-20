using PhoneBookMaui.viewModel;

namespace PhoneBookMaui.view;

public partial class UserList : ContentPage
{
	public UserList()
	{
		InitializeComponent();
		BindingContext = new UserListVM();

	}
}