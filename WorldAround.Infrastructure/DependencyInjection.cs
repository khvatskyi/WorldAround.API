using Azure.Storage.Blobs;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using WorldAround.Application.Interfaces.Infrastructure;
using WorldAround.Domain.Entities;
using WorldAround.Infrastructure.Data;
using WorldAround.Infrastructure.Storage;

namespace WorldAround.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = Environment.GetEnvironmentVariable("WA_DB_CONNECTION");

        services.AddDbContext<WorldAroundDbContext>(options => options.UseSqlServer(connectionString))
            .AddScoped<IWorldAroundDbContext, WorldAroundDbContext>();

        services.AddIdentity<User, Role>()
            .AddEntityFrameworkStores<WorldAroundDbContext>();

        services.Configure<IdentityOptions>(options =>
        {
            // Password settings.
            options.Password.RequireDigit = false;
            options.Password.RequireLowercase = false;
            options.Password.RequireNonAlphanumeric = false;
            options.Password.RequireUppercase = false;
            options.Password.RequiredLength = 1;
            options.Password.RequiredUniqueChars = 1;

            // Email settings.
            options.User.RequireUniqueEmail = true;

            // Lockout settings.
            options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
            options.Lockout.MaxFailedAccessAttempts = 100;
            options.Lockout.AllowedForNewUsers = true;

            // User settings.
            options.User.AllowedUserNameCharacters =
                "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._+";
        });

        services.AddScoped<IBlobStorageGateway, BlobStorageGateway>(_ =>
            new BlobStorageGateway(
                new BlobServiceClient(configuration.GetValue<string>("AzureStorageConnectionString"))));

        return services;
    }
}
