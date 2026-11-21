using SFMS.MAUI.Models.Authentication;
using System.Net;
using System.Net.Http.Json;
using System.Text.Json;

namespace SFMS.MAUI.Services.Api;

public sealed class AuthenticationService(
    HttpClient httpClient)
{
    private readonly HttpClient _httpClient = httpClient;

    private static readonly JsonSerializerOptions JsonOptions =
        new(JsonSerializerDefaults.Web)
        {
            PropertyNameCaseInsensitive = true
        };

    public async Task<LoginResponse?> LoginAsync(
        LoginRequest request,
        CancellationToken cancellationToken = default)
    {
        using var response =
            await _httpClient.PostAsJsonAsync(
                "api/auth/login",
                request,
                JsonOptions,
                cancellationToken);

        if (response.StatusCode ==
            HttpStatusCode.Unauthorized)
        {
            return null;
        }

        var responseBody =
            await response.Content.ReadAsStringAsync(
                cancellationToken);

        System.Diagnostics.Debug.WriteLine(
            $"SFMS LOGIN STATUS: {(int)response.StatusCode}");

        System.Diagnostics.Debug.WriteLine(
            $"SFMS LOGIN RESPONSE: {responseBody}");

        if (!response.IsSuccessStatusCode)
        {
            throw new HttpRequestException(
                $"SFMS API returned " +
                $"{(int)response.StatusCode} " +
                $"{response.ReasonPhrase}. " +
                $"Response: {responseBody}");
        }

        try
        {
            var result =
                JsonSerializer.Deserialize<LoginResponse>(
                    responseBody,
                    JsonOptions);

            return result is null
                ? throw new InvalidOperationException(
                    "SFMS API returned an empty login response.")
                : result;
        }
        catch (JsonException exception)
        {
            throw new InvalidOperationException(
                "SFMS API login succeeded, but the response " +
                "could not be converted to LoginResponse. " +
                $"Response: {responseBody}",
                exception);
        }
    }

    public async Task<bool> CheckServerAsync(
        CancellationToken cancellationToken = default)
    {
        try
        {
            using var response =
                await _httpClient.GetAsync(
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