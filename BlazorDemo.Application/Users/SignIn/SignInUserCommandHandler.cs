using BlazorDemo.Domain.Users;
using MediatR;

namespace BlazorDemo.Application.Users.SignIn;

internal sealed class SignInUserCommandHandler : IRequestHandler<SignInUserCommand, bool>
{
    private readonly IUserRepository _userRepository;

    public SignInUserCommandHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public Task<bool> Handle(SignInUserCommand request, CancellationToken cancellationToken)
    {
       var canSignIn = _userRepository.SignIn(request.Email, request.Password);

       return Task.FromResult(canSignIn);
    }
}
