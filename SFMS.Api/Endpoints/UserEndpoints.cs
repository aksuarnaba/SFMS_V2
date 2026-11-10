using MediatR;
using SFMS.Application.Features.Users.Queries.GetUsers;

namespace SFMS.Api.Endpoints
{
    public static class UserEndpoints
    {
        public static IEndpointRouteBuilder MapUserEndpoints(
            this IEndpointRouteBuilder app)
        {
            var group = app.MapGroup("/api/users")
                .WithTags("Users")
                .RequireAuthorization("AdminOrSuperadmin");

            group.MapGet("/", async (
                int? pageNumber,
                int? pageSize,
                ISender sender,
                CancellationToken cancellationToken) =>
            {
                var query = new GetUsersQuery(
                    pageNumber ?? 1,
                    pageSize ?? 20);

                var result = await sender.Send(
                    query,
                    cancellationToken);

                return Results.Ok(result);
            })
            .WithName("GetUsers")
            .WithSummary("Get paginated users.");

            return app;
        }
    }
}
