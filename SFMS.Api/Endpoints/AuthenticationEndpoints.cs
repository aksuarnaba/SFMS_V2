using MediatR;
using SFMS.Api.Contracts.Authentication;
using SFMS.Application.Features.Authentication.Commands.Login;

namespace SFMS.Api.Endpoints
{
    
    public static class AuthenticationEndpoints
    {
        public static IEndpointRouteBuilder MapAuthenticationEndpoints(
            this IEndpointRouteBuilder app)
        {
            var group = app.MapGroup("/api/auth")
                .WithTags("Authentication");

            group.MapPost("/login", async (
                LoginRequest request,
                ISender sender,
                CancellationToken cancellationToken) =>
            {
                try
                {
                    var command = new LoginCommand(
                        request.Site,
                        request.EmployeeNumber,
                        request.Password);

                    var result = await sender.Send(
                        command,
                        cancellationToken);

                    return Results.Ok(result);
                }
                catch (UnauthorizedAccessException)
                {
                    return Results.Unauthorized();
                }
            })
            .AllowAnonymous()
            .WithName("Login")
            .WithSummary("Authenticate an SFMS user.");

            return app;
        }
    }

}
