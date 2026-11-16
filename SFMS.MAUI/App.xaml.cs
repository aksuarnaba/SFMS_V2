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
                Width = 550,
                Height = 750,

                MinimumWidth = 450,
                MinimumHeight = 650,

                MaximumWidth = 550,
                MaximumHeight = 850
            };
            return window;
        }
    }
}