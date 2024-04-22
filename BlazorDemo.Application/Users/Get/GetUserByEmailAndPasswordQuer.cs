using BlazorDemo.Domain.Users;
using MediatR;

namespace BlazorDemo.Application.Users.Get;

public record GetUserByEmailAndPasswordQuery(
    string Email, 
    string Password) : IRequest<User>;
