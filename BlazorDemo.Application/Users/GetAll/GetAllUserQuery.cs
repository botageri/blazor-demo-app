using BlazorDemo.Domain.Users;
using MediatR;

namespace BlazorDemo.Application.Users.GetAll;

public record GetAllUserQuery() : IRequest<List<User>>;
