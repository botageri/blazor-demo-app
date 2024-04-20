using BlazorDemo.Domain.Primitives;

namespace BlazorDemo.Domain.Users;

public interface IUserRepository : IRepository<User>
{
    bool SignIn(string username, string password);
    bool AnySameAuthentication(int id, string username, string password);
}
