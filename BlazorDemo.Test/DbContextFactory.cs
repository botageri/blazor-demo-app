using BlazorDemo.Infrastructure;
using BlazorDemo.Infrastructure.Users;

namespace BlazorDemo.Test;

public static class DbContextFactory
{
    private const string fileName = "testUserDB.json";
    public static JsonApplicationDbContext GetDbContext()
    {
        var path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, fileName);
        return JsonApplicationDbContext.Create(path);
    }
}
