using PhoneBookMaui.viewModel;

namespace PhoneBookMaui.view;

public partial class UserList : ContentPage
{
	public UserList(UserListVM vm)
	{
		InitializeComponent();
		BindingContext = vm;

	}
}