using SFMS.MAUI.Views.Layout;
using SFMS.MAUI.Views.Authentication;
using System;
using System.Collections.Generic;
using System.Text;

namespace SFMS.MAUI.Services.Navigation
{
    public class NavigationService(IServiceProvider serviceProvider) : INavigationService
    {
        private readonly IServiceProvider _serviceProvider = serviceProvider;

        public Task GoToLoginAsync()
        {
            var loginPage = _serviceProvider.GetRequiredService<LoginPage>();

            return SetRootPageAsync(loginPage);
        }

        public Task GoToMainAsync()
        {
            var mainPage = _serviceProvider.GetRequiredService<MainPage>();

             return SetRootPageAsync(mainPage);
        }

        public static Task SetRootPageAsync(Page page)
        {
            return MainThread.InvokeOnMainThreadAsync(() =>
            {
                var windows = Application.Current?.Windows;
                if (windows is null || windows.Count == 0)
                {
                    throw new InvalidOperationException(
                        "The SFMS application window is not available.");
                }

                windows[0].Page = page;
            });

        }
    }
}
