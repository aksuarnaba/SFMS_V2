using SFMS.MAUI.Views.Authentication;

namespace SFMS.MAUI;

public partial class App : Application
{
    private readonly IServiceProvider _serviceProvider;

    public App(IServiceProvider serviceProvider)
    {
        InitializeComponent();

        _serviceProvider = serviceProvider;
    }

    protected override Window CreateWindow(
        IActivationState? activationState)
    {
        var loginPage =
            _serviceProvider.GetRequiredService<LoginPage>();

        var window = new Window(loginPage);

#if WINDOWS

        window.Title =
            "SFMS - Shopfloor Management System";

        window.Width = 1180;
        window.Height = 760;

        window.MinimumWidth = 900;
        window.MinimumHeight = 650;

#endif

        return window;
    }
}