using BlazorDemo.Infrastructure;

namespace BlazorDemo.Test;

public abstract class DbTest
{
    protected readonly JsonApplicationDbContext _dbContext = DbContextFactory.GetDbContext();
}
