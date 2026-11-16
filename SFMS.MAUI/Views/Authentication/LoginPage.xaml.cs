using SFMS.MAUI.ViewModels.Authentication;

namespace SFMS.MAUI.Views.Authentication;

public partial class LoginPage : ContentPage
{
	public LoginPage(LoginViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;

    }
}