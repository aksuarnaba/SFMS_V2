using CommunityToolkit.Maui;
using LiveChartsCore.SkiaSharpView.Maui;
using Microsoft.Extensions.Logging;
using SFMS.MAUI.Services.Api;
using SFMS.MAUI.Services.Authentication;
using SFMS.MAUI.Services.Dashboard;
using SFMS.MAUI.Services.Navigation;
using SFMS.MAUI.ViewModels.Authentication;
using SFMS.MAUI.ViewModels.Dashboard;
using SFMS.MAUI.Views.Authentication;
using SFMS.MAUI.Views.Dashboard;
using SFMS.MAUI.Views.Layout;
using SkiaSharp.Views.Maui.Controls.Hosting;
using UraniumUI;

namespace SFMS.MAUI
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();

            builder
                .UseMauiApp<App>()
                .UseMauiCommunityToolkit()
                .UseUraniumUI()
                .UseUraniumUIMaterial()
                .UseSkiaSharp()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont(
                        "OpenSans-Regular.ttf",
                        "OpenSansRegular");

                    fonts.AddFont(
                        "OpenSans-Semibold.ttf",
                        "OpenSansSemibold");

                    fonts.AddFont(
                        "Montserrat-ExtraBold.ttf",
                        "MontserratExtraBold");

                    fonts.AddFont(
                        "Lato-Black.ttf",
                        "LatoBlack");

                    fonts.AddFont(
                        "Lato-Bold.ttf",
                        "LatoBold");

                    fonts.AddFont(
                        "Lato-BoldItalic.ttf",
                        "LatoBoldItalic");

                    fonts.AddFont(
                        "Lato-Regular.ttf",
                        "LatoRegular");

                    fonts.AddFont(
                        "Lato-Light.ttf",
                        "LatoLight");


                    // General UI and form text
                    fonts.AddFont(
                        "Inter_18pt-Regular.ttf",
                        "InterRegular");

                    fonts.AddFont(
                        "Inter_18pt-Medium.ttf",
                        "InterMedium");

                    fonts.AddFont(
                        "Inter_18pt-SemiBold.ttf",
                        "InterSemiBold");

                    // Headings
                    fonts.AddFont(
                        "Inter_24pt-Bold.ttf",
                        "InterBold");

                    // SFMS branding and major metrics
                    fonts.AddFont(
                        "Inter_28pt-ExtraBold.ttf",
                        "InterExtraBold");

                });

            var apiBaseUrl = GetApiBaseUrl();

            // Secure application session
            builder.Services.AddSingleton<ISecureStorage>(
                SecureStorage.Default);

            builder.Services.AddSingleton<SessionService>();

            // Authentication
            builder.Services.AddHttpClient<AuthenticationService>(
                client =>
                {
                    client.BaseAddress =
                        new Uri(apiBaseUrl);

                    client.Timeout =
                        TimeSpan.FromSeconds(15);
                });

            

            builder.Services.AddTransient<LoginViewModel>();
            builder.Services.AddTransient<LoginPage>();


            // Navigation
            builder.Services.AddSingleton<
                INavigationService,
                NavigationService>();

            // Dashboard
            builder.Services.AddSingleton<
                IDashboardService,
                MockDashboardService>();

            builder.Services.AddTransient<
                DashboardViewModel>();

            builder.Services.AddTransient<
                DashboardView>();


            // Main authenticated application
            builder.Services.AddTransient<
                MainPage>();



#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }

        private static string GetApiBaseUrl()
        {
#if ANDROID
            // Android emulator accessing the development PC.
            return "https://10.0.2.2:7280";
#else
            return "https://localhost:7280";
#endif
        }
    }
}
