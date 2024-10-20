using PhoneBookMaui.viewModel;

namespace PhoneBookMaui.view;

public partial class SignInPage : ContentPage
{
	public SignInPage()
	{
		InitializeComponent();
		BindingContext = new SignUserVM();	
	}
}