using SFMS.Application.Common.Interfaces.Security;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using SFMS.Api.Endpoints;
using SFMS.Application;
using SFMS.Domain.Enums;
using SFMS.Infrastructure;
using SFMS.Infrastructure.Persistence.Context;
using SFMS.Infrastructure.Persistence.Seeders;
using SFMS.Infrastructure.Security;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Load User Secrets in development
if (builder.Environment.IsDevelopment())
{
    builder.Configuration.AddUserSecrets<Program>();
}

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services.AddApplication();
builder.Services.AddInfrastructure(builder.Configuration);

var jwtSettings = builder.Configuration
    .GetSection(JwtSettings.SectionName)
    .Get<JwtSettings>()
    ?? throw new InvalidOperationException("JWT configuration is missing.");

if (string.IsNullOrWhiteSpace(jwtSettings.SecretKey))
{
    throw new InvalidOperationException("JWT Secret Key is missing.");
}

//Aron Kyle Suarnaba - JWT Authentication
builder.Services
    .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,

            IssuerSigningKey = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(jwtSettings.SecretKey)),

            ValidateIssuer = true,
            ValidIssuer = jwtSettings.Issuer,

            ValidateAudience = true,
            ValidAudience = jwtSettings.Audience,

            ValidateLifetime = true,

            ClockSkew = TimeSpan.FromSeconds(30),
            RoleClaimType = System.Security.Claims.ClaimTypes.Role
        };
    });

builder.Services.AddAuthorizationBuilder()
    .AddPolicy("AdminOrSuperadmin", policy =>
        policy.RequireRole(
            nameof(UserRoleEnums.Superadmin),
            nameof(UserRoleEnums.Admin)));

builder.Services.AddProblemDetails();

var app = builder.Build();

// --- RUN THE DATABASE SEEDER ---
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;

    var context =
        services.GetRequiredService<SFMSDbContext>();

    var passwordHasher =
        services.GetRequiredService<IPasswordHasher>();

    var initialAdminPassword =
        builder.Configuration[
            "InitialAdmin:Password"];

    try
    {
        Console.WriteLine(
            "Starting SFMS master-data seeding...");

        await SFMSDbContextSeeder.SeedAsync(
            context,
            passwordHasher,
            initialAdminPassword);

        Console.WriteLine(
            "SFMS master-data seeding completed.");
    }
    catch (Exception exception)
    {
        app.Logger.LogCritical(
            exception,
            "SFMS database seeding failed.");

        throw;
    }
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}


app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapAuthenticationEndpoints();
app.MapUserEndpoints();

app.Run();