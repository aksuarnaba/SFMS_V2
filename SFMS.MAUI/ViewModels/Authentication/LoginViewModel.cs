using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using SFMS.MAUI.Models.Authentication;
using SFMS.MAUI.Services.Navigation;
using SFMS.MAUI.Services.Authentication;
using SFMS.MAUI.Services.Api;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace SFMS.MAUI.ViewModels.Authentication
{
    public partial class LoginViewModel : ObservableObject
    {
        private readonly AuthenticationService _authenticationService;
        private readonly SessionService _sessionService;
        private readonly INavigationService _navigationService;

        public ObservableCollection<SiteOption> Sites { get; } =
            [
                new(1, "PI-SP", "Printwell, Inc."),
                new(2, "FP-SP", "Fortune Packaging Corp."),
                new(3, "PIGRP-SP", "Printwell Packaging Corp.")
            ];

        [ObservableProperty]
        [NotifyCanExecuteChangedFor(nameof(LoginCommand))]
        public partial SiteOption? SelectedSite { get; set; }

        [ObservableProperty]
        [NotifyCanExecuteChangedFor(nameof(LoginCommand))]
        public partial string EmployeeNumber { get; set; } = string.Empty;

        [ObservableProperty]
        [NotifyCanExecuteChangedFor(nameof(LoginCommand))]
        public partial string Password { get; set; } = string.Empty;

        [ObservableProperty]
        public partial string Message { get; set; } = string.Empty;

        [ObservableProperty]
        public partial bool IsBusy { get; set; }

        [ObservableProperty]
        public partial bool HasError { get; set; }


        public LoginViewModel(AuthenticationService authenticationService, SessionService sessionService, INavigationService navigationService)
        {
            _authenticationService = authenticationService;
            _sessionService = sessionService;
            _navigationService = navigationService;

            SelectedSite = Sites[0];
        }

        private bool CanLogin()
        {
            return !IsBusy &&
                   SelectedSite is not null &&
                   !string.IsNullOrWhiteSpace(EmployeeNumber) &&
                   !string.IsNullOrWhiteSpace(Password);
        }

        [RelayCommand(CanExecute = nameof(CanLogin))]
        private async Task LoginAsync()
        {

            Message = string.Empty;
            HasError = false;
            IsBusy = true;
            LoginCommand.NotifyCanExecuteChanged();

            try
            {
                var request = new LoginRequest(
    SelectedSite!.Value,
    EmployeeNumber.Trim().ToUpperInvariant(),
    Password);

                System.Diagnostics.Debug.WriteLine(
                    $"LOGIN → API | Site={request.Site}, " +
                    $"Employee={request.EmployeeNumber}");

                var response =
                    await _authenticationService.LoginAsync(
                        request);

                if (response is null)
                {
                    HasError = true;

                    Message =
                        "The site, employee number, or password is incorrect.";

                    return;
                }

                System.Diagnostics.Debug.WriteLine(
                    "LOGIN → API authentication successful.");

                await _sessionService.SaveAsync(response);

                System.Diagnostics.Debug.WriteLine(
                    "LOGIN → SecureStorage successful.");

                Password = string.Empty;

                await _navigationService.GoToMainAsync();

                System.Diagnostics.Debug.WriteLine(
                    "LOGIN → Navigation successful.");
            }
            catch (HttpRequestException)
            {
                HasError = true;
                Message =
                    "The SFMS server cannot be reached. Check the production network connection.";
            }
            catch (TaskCanceledException)
            {
                HasError = true;
                Message =
                    "The server did not respond in time. Please try again.";
            }
            catch (Exception exception)
            {
                System.Diagnostics.Debug.WriteLine(
                    "========== SFMS LOGIN FAILURE ==========");

                System.Diagnostics.Debug.WriteLine(
                    exception.ToString());

                System.Diagnostics.Debug.WriteLine(
                    "========================================");

                HasError = true;

                #if DEBUG
                                Message =
                                    $"{exception.GetType().Name}: " +
                                    $"{exception.Message}";
                #else
                    Message =
                        "The sign-in request could not be completed.";
                #endif
                            }
            finally
            {
                IsBusy = false;
                LoginCommand.NotifyCanExecuteChanged();
            }
        }

        partial void OnEmployeeNumberChanged(string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                return;
            }

            var normalizedValue =
                value.ToUpperInvariant();

            if (!string.Equals(
                    value,
                    normalizedValue,
                    StringComparison.Ordinal))
            {
                EmployeeNumber =
                    normalizedValue;
            }
        }
    }
}