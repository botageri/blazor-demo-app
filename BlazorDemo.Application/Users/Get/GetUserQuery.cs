using BlazorDemo.Domain.Users;
using MediatR;

namespace BlazorDemo.Application.Users.GetAll;

public record GetUserQuery(int Id) : IRequest<User>;
