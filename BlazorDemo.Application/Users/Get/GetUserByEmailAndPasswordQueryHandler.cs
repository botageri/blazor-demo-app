using BlazorDemo.Domain.Primitives;
using BlazorDemo.Domain.Users;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorDemo.Application.Users.Get;

internal sealed class GetUserByEmailAndPasswordQueryHandler : IRequestHandler<GetUserByEmailAndPasswordQuery, User>
{
    private readonly IUserRepository _userRepository;

    public GetUserByEmailAndPasswordQueryHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public Task<User> Handle(GetUserByEmailAndPasswordQuery request, CancellationToken cancellationToken)
    {
        var user = (from u in _userRepository.GetAll()
                   where u.Email == request.Email && u.Password == request.Password
                   select u).FirstOrDefault();

        return Task.FromResult(user);
    }
}
