using SFMS.Domain.Enums;

namespace SFMS.Api.Contracts.Authentication
{
    public sealed record LoginRequest(SiteEnums Site, string EmployeeNumber, string Password);
}
