using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using SFMS.Application.Common.Interfaces;
using SFMS.Application.DTOs.Auth;

namespace SFMS.Api.Endpoints
{
    public static class LoginEndpoints
    {
        public static IEndpointRouteBuilder MapLoginEndpoints(this IEndpointRouteBuilder app)
        {
            app.MapPost("api/v1/auth/login", async (LoginRequest request, IAuthService authService, CancellationToken ct) =>
            {
                var token = await authService.LoginAsync(request, ct);

                return token is not null
                    ? Results.Ok(new
                    {
                        Token = token
                    })
                    : Results.Unauthorized();
            })
                .WithTags("Authentication");

            return app;
        }
    }
}
