using PhoneBookMaui.viewModel;

namespace PhoneBookMaui.view;

public partial class SignInPage : ContentPage
{
	public SignInPage(SignUserVM vm)
	{
		InitializeComponent();
		BindingContext = vm;	
	}
}