using PhoneBookMaui.viewModel;
using System.Runtime.CompilerServices;

namespace PhoneBookMaui.view;

public partial class AddUserPage : ContentPage
{
	public AddUserPage()
	{
		InitializeComponent();
		BindingContext = new AddUserVM();
	}
}