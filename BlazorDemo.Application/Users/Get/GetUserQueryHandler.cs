using BlazorDemo.Application.Data;
using BlazorDemo.Domain.Primitives;
using BlazorDemo.Domain.Users;
using MediatR;
using MediatR.Wrappers;

namespace BlazorDemo.Application.Users.GetAll;

internal sealed class GetUserQueryHandler : IRequestHandler<GetUserQuery, User>
{
    private readonly IUserRepository _userRepository;

    public GetUserQueryHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public Task<User> Handle(GetUserQuery request, CancellationToken cancellationToken)
    {
        var users = _userRepository.Get(request.Id);

        if (users is null)
            throw new DomainException($"A keresett felhasználó nem található! Id={request.Id}");

        return Task.FromResult(users);
    }
}
