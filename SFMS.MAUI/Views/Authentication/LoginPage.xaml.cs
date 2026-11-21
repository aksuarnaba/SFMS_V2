using SFMS.MAUI.ViewModels.Authentication;

namespace SFMS.MAUI.Views.Authentication;

public partial class LoginPage : ContentPage
{
	public LoginPage(LoginViewModel viewModel)
	{
        InitializeComponent();
		BindingContext = viewModel;

    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();

        LoginCard.Opacity = 0;
        LoginCard.TranslationY = 20;

        BrandContent.Opacity = 0;
        BrandContent.TranslationX = -20;

        await Task.WhenAll(
            BrandContent.FadeToAsync(
                1,
                400,
                Easing.CubicOut),

            BrandContent.TranslateToAsync(
                0,
                0,
                400,
                Easing.CubicOut),

            LoginCard.FadeToAsync(
                1,
                450,
                Easing.CubicOut),

            LoginCard.TranslateToAsync(
                0,
                0,
                450,
                Easing.CubicOut));
    }
}