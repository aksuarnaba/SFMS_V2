using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace SFMS.MAUI.ViewModels.Authentication
{
    public partial class LoginViewModel : ObservableObject
    {
        [ObservableProperty]
        public partial string EmployeeNumber { get; set; } = string.Empty;

        [ObservableProperty]
        public partial string Password { get; set; } = string.Empty;

        [ObservableProperty]
        public partial string Message { get; set; } = string.Empty;

        [RelayCommand]
        private void Login()
        {
            Message = $"Welcome, {EmployeeNumber}";
        }

        public ObservableCollection<string> Companies { get; } =
            [
                "Printwell, Inc.",
                "Fortune Packaging Corp.",
                "Printwell Packaging Corp."
            ];

        public ObservableCollection<string> Shifts { get; } =
            [
                "Dayshift",
                "Midshift",
                "Nightshift"
            ];
    }
}