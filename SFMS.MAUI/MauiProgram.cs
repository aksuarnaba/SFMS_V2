using CommunityToolkit.Maui;
using LiveChartsCore.SkiaSharpView.Maui;
using Microsoft.Extensions.Logging;
using SFMS.MAUI.Services.Api;
using SFMS.MAUI.Services.Authentication;
using SFMS.MAUI.ViewModels.Authentication;
using SFMS.MAUI.Views.Authentication;
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
                });

            var apiBaseUrl = GetApiBaseUrl();

            builder.Services.AddSingleton(
                new ApiSettings
                {
                    BaseUrl = apiBaseUrl
                });

            builder.Services.AddHttpClient<AuthenticationService>(
                client =>
                {
                    client.BaseAddress = new Uri(apiBaseUrl);
                    client.Timeout = TimeSpan.FromSeconds(15);
                });

            builder.Services.AddSingleton<SessionService>();

            builder.Services.AddTransient<LoginViewModel>();
            builder.Services.AddTransient<LoginPage>();

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
