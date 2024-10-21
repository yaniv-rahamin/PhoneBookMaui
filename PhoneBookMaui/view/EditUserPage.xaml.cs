using PhoneBookMaui.viewModel;

namespace PhoneBookMaui.view;

public partial class EditUserPage : ContentPage
{
	public EditUserPage(EditUserVM vm)
	{
		InitializeComponent();
		BindingContext = vm;
	}
}