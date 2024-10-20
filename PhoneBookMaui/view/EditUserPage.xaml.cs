using PhoneBookMaui.viewModel;

namespace PhoneBookMaui.view;

public partial class EditUserPage : ContentPage
{
	public EditUserPage()
	{
		InitializeComponent();
		BindingContext = new EditUserVM();
	}
}