using MediatR;

namespace BlazorDemo.Application.Users.SignIn;

public record SignInUserCommand(
        string Email,
        string Password
    ) : IRequest<bool>;
