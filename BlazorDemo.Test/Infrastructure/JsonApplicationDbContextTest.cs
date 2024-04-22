using BlazorDemo.Infrastructure;
using BlazorDemo.Domain.Users;
using BlazorDemo.Domain.Addresses;

namespace BlazorDemo.Test.Infrastructure;

public class JsonApplicationDbContextTest : DbTest
{
    [Fact]
    public void SaveChangesAsync_Test()
    {
        var user = new User()
        {
            FirstName = "Elek",
            LastName = "Test",
            City = new City("5000", "Szolnok"),
            Address = "Szigligeti út 6",
            Email = "teszt@elek.com",
            Password = "teszt",
            BirthDate = new DateTime(2000, 1, 2),
            BirthPlace = "Budapest",
            PhoneNumber = "1234567890"
        };

        _dbContext.Users.Add(user);

        Assert.Contains(user, _dbContext.Users);

        _dbContext.SaveChangesAsync(CancellationToken.None);

        var dbContext = DbContextFactory.GetDbContext();

        Assert.Contains(user, dbContext.Users);
    }
}