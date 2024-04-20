using BlazorDemo.Domain.Addresses;
using BlazorDemo.Domain.Users;
using MediatR;

namespace BlazorDemo.Application.Users.Save;

public record SaveUserCommand(User User) : IRequest;
