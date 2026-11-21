using SFMS.MAUI.Models.Authentication;

namespace SFMS.MAUI.Services.Authentication;

public sealed class SessionService(
    ISecureStorage secureStorage)
{
    private const string AccessTokenKey =
        "sfms_access_token";

    private const string EmployeeNumberKey =
        "sfms_employee_number";

    private const string DisplayNameKey =
        "sfms_display_name";

    private const string SiteKey =
        "sfms_site";

    private const string RoleKey =
        "sfms_role";

    private readonly ISecureStorage _secureStorage = secureStorage;

    public async Task SaveAsync(
        LoginResponse response)
    {
        ArgumentNullException.ThrowIfNull(response);

        await _secureStorage.SetAsync(
            AccessTokenKey,
            response.AccessToken);

        await _secureStorage.SetAsync(
            EmployeeNumberKey,
            response.EmployeeNumber);

        await _secureStorage.SetAsync(
            DisplayNameKey,
            response.Name);

        await _secureStorage.SetAsync(
            SiteKey,
            response.Site.ToString());

        await _secureStorage.SetAsync(
            RoleKey,
            response.Role.ToString());
    }

    public Task<string?> GetAccessTokenAsync()
    {
        return _secureStorage.GetAsync(
            AccessTokenKey);
    }

    public Task<string?> GetEmployeeNumberAsync()
    {
        return _secureStorage.GetAsync(
            EmployeeNumberKey);
    }

    public Task<string?> GetDisplayNameAsync()
    {
        return _secureStorage.GetAsync(
            DisplayNameKey);
    }

    public Task<string?> GetSiteAsync()
    {
        return _secureStorage.GetAsync(
            SiteKey);
    }

    public Task<string?> GetRoleAsync()
    {
        return _secureStorage.GetAsync(
            RoleKey);
    }

    public void Clear()
    {
        _secureStorage.Remove(
            AccessTokenKey);

        _secureStorage.Remove(
            EmployeeNumberKey);

        _secureStorage.Remove(
            DisplayNameKey);

        _secureStorage.Remove(
            SiteKey);

        _secureStorage.Remove(
            RoleKey);
    }
}