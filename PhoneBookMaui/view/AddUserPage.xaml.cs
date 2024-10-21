using PhoneBookMaui.viewModel;
using System.Runtime.CompilerServices;

namespace PhoneBookMaui.view;

public partial class AddUserPage : ContentPage
{
	public AddUserPage(AddUserVM vm)
	{
		InitializeComponent();
		BindingContext =vm;
	}
}