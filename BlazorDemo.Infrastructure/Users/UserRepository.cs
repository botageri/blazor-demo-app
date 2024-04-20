using BlazorDemo.Domain.Users;

namespace BlazorDemo.Infrastructure.Users;

public class UserRepository : Repository<User>, IUserRepository
{
    public UserRepository(JsonApplicationDbContext dbContext) : base(dbContext)
    {
    }

    public bool AnySameAuthentication(int id, string email, string password)
    {
        var isExist = DbContext.Users.Any(
            user => user.Id != id && user.Email == email && user.Password == password);

        return isExist;
    }

    public bool SignIn(string email, string password)
    {
        var isExist = DbContext.Users.Any(
            user => user.Email == email && user.Password == password);

        return isExist;
    }
}
