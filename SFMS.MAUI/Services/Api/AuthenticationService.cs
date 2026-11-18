using SFMS.MAUI.Models.Authentication;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http.Json;
using System.Text;

namespace SFMS.MAUI.Services.Api
{
    public sealed class AuthenticationService
    {
        private readonly HttpClient _httpClient;

        public AuthenticationService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<LoginResponse?> LoginAsync(
            LoginRequest request,
            CancellationToken ct = default)
        {
            using var response = await _httpClient.PostAsJsonAsync(
                "api/auth/login", request, ct);

            if(response.StatusCode == HttpStatusCode.Unauthorized)
            {
                return null;
            }

            response.EnsureSuccessStatusCode();

            return await response.Content.ReadFromJsonAsync<LoginResponse>(
                cancellationToken: ct);

        }

        public async Task<bool> CheckServerAsync(
            CancellationToken cancellationToken = default)
        {
            try
            {
                using var response = await _httpClient.GetAsync(
                    "health",
                    cancellationToken);

                return response.IsSuccessStatusCode;
            }
            catch (HttpRequestException)
            {
                return false;
            }
            catch (TaskCanceledException)
            {
                return false;
            }
        }

    }
}
