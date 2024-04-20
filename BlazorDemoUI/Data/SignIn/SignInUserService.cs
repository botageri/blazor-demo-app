using MediatR;
using BlazorDemo.Application.Users.SignIn;
using BlazorDemo.Domain.Users;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace BlazorDemoUI.Data.SignIn;

public sealed class SignInUserService
{
    private readonly IMediator _mediator;
    
    public SignInUserService(IMediator mediator)
    {
        _mediator = mediator;
    }

    public async Task<bool> SignInAsync(string email, string password)
        => await _mediator.Send(new SignInUserCommand(email, password));
}
