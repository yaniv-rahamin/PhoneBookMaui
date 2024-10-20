using PhoneBookMaui.viewModel;

namespace PhoneBookMaui.view;

public partial class LogINPage : ContentPage
{
	public LogINPage()
	{
		InitializeComponent();
		BindingContext = new LogInVM();
	}
}