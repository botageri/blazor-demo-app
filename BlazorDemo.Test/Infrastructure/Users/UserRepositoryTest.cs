using BlazorDemo.Infrastructure.Users;

namespace BlazorDemo.Test.Infrastructure.Users;

public class UserRepositoryTest : DbTest
{
    private readonly UserRepository _userRepository;

    public UserRepositoryTest()
    {
        _userRepository = new UserRepository(_dbContext);
    }

    [Fact]
    public void SignIn_Test()
    {
        Assert.False(_userRepository.SignIn("teszt@ele", "teszt"));
        Assert.True(_userRepository.SignIn("teszt@elek.com", "teszt"));
    }
}
