using SFMS.MAUI.Models.Authentication;
using System;
using System.Collections.Generic;
using System.Text;

namespace SFMS.MAUI.Services.Authentication
{
    public sealed class SessionService
    {
        private const string AccessTokenKey = "sfms_access_token";
        private const string EmployeeNumberKey = "sfms_employee_number";
        private const string DisplayNameKey = "sfms_display_name";

        public async Task SaveAsync(LoginResponse response)
        {
            await SecureStorage.Default.SetAsync(AccessTokenKey, response.AccessToken);

            await SecureStorage.Default.SetAsync(EmployeeNumberKey, response.EmployeeNumber);

            await SecureStorage.Default.SetAsync(DisplayNameKey, response.Name);
        }

        public Task<string?> GetAccessTokenAsync()
        {
            return SecureStorage.Default.GetAsync(AccessTokenKey);
        }

        public void Clear()
        {
            SecureStorage.Default.Remove(AccessTokenKey);
            SecureStorage.Default.Remove(EmployeeNumberKey);
            SecureStorage.Default.Remove(DisplayNameKey);
        }

    }
}
