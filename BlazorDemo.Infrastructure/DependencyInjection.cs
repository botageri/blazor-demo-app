using BlazorDemo.Application.Data;
using BlazorDemo.Domain.Users;
using BlazorDemo.Infrastructure.Users;
using Microsoft.Extensions.DependencyInjection;

namespace BlazorDemo.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, string dbPath)
    {
        var dbContext = JsonApplicationDbContext.Create(dbPath);

        services.AddSingleton<JsonApplicationDbContext>(dbContext);
        services.AddSingleton<IUnitOfWork>(dbContext);
        services.AddScoped<IUserRepository, UserRepository>();

        return services;
    }
}
