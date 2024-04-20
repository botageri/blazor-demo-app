using BlazorDemo.Application.Data;
using BlazorDemo.Domain.Users;
using MediatR;
using MediatR.Wrappers;

namespace BlazorDemo.Application.Users.GetAll;

internal sealed class GetAllUserQueryHandler : IRequestHandler<GetAllUserQuery, List<User>>
{
    private readonly IUserRepository _userRepository;

    public GetAllUserQueryHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public Task<List<User>> Handle(GetAllUserQuery request, CancellationToken cancellationToken)
    {
        var users = _userRepository.GetAll().ToList();
        return Task.FromResult(users);
    }
}
