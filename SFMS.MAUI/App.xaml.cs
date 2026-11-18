using SFMS.MAUI.Views.Authentication;

namespace SFMS.MAUI
{
    public partial class App : Application
    {
        private readonly IServiceProvider _serviceProvider;

        public App(IServiceProvider serviceProvider)
        {
            InitializeComponent();
            _serviceProvider = serviceProvider;
        }

        protected override Window CreateWindow(IActivationState? activationState)
        {
            var loginPage = _serviceProvider.GetRequiredService<LoginPage>();

            var window = new Window(loginPage)
            {

                Title = "SFMS - Shopfloor Management System",

                Width = 1180,
                Height = 760,

                MinimumWidth = 900,
                MinimumHeight = 650,

            };
            return window;
        }
    }
}