using SFMS.Application.Common.Interfaces;
using SFMS.Application.Common.Mappings;
using SFMS.Application.DTOs.Employees;
using SFMS.Application.Features.Employees;
using SFMS.Domain.Entities;

namespace SFMS.Api.Endpoints
{
    public static class UserEndpoints
    {
        public static IEndpointRouteBuilder MapUserEndpoints(this IEndpointRouteBuilder app)
        {
            var group = app.MapGroup("/api/v1/users")
                .WithTags("Users");

            group.MapGet("/", async (int page, int pagedSize, string search, IUserRepository repo, CancellationToken ct = default) =>
            {
                var users = await repo.GetPagedAsync(page, pagedSize, search, ct);
                return Results.Ok(users);
            });

            group.MapGet("/{id:int}", async (int id, IUserRepository repo, CancellationToken ct = default) =>
            {
                var user = await repo.GetByIdAsync(id, ct);

                return user is not null
                    ? Results.Ok(user)
                    : Results.NotFound(new
                    {
                        Message = $"Employee with ID {id} not found!"
                    });
            });

            group.MapPost("/", async (UserDtoRequest request, IUserRepository repo, IUnitOfWork unitofWork, IPasswordRepository passwordRepository, CancellationToken ct = default) =>
            {
                if (string.IsNullOrWhiteSpace(request.EmpNum) || string.IsNullOrWhiteSpace(request.Password))
                {
                    return Results.BadRequest(new
                    {
                        Message = "Employee number and password is required!"
                    });
                }

                var user = EmployeeMapper.MapToEntity(request);

                user.PasswordHash = passwordRepository.HashPassword(user, request.Password);

                await repo.AddAsync(user, ct);

                await unitofWork.SaveChangesAsync(ct);

                return Results.Created($"/api/v1/users/{user.Id}", new
                {
                    Message = "User created successfully"
                });
            })
                .RequireAuthorization();

            return app;

        }
    }
}
