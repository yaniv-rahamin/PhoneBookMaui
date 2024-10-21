using PhoneBookMaui.viewModel;

namespace PhoneBookMaui.view;

public partial class LogINPage : ContentPage
{
	public LogINPage(LogInVM vm)
	{
		InitializeComponent();
		BindingContext = vm;
	}
}