using BlazorDemo.Application.Data;
using BlazorDemo.Domain.Users;
using MediatR;

namespace BlazorDemo.Application.Users.Save;

internal sealed class SaveUserCommandHandler : IRequestHandler<SaveUserCommand>
{
    private readonly IUserRepository _userRepository;
    private readonly IUnitOfWork _unitOfWork;

    public SaveUserCommandHandler(IUserRepository userRepository, IUnitOfWork unitOfWork)
    {
        _userRepository = userRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task Handle(SaveUserCommand request, CancellationToken cancellationToken)
    {
        if (_userRepository.AnySameAuthentication(request.User.Id, request.User.Email, request.User.Password))
            throw new Exception("Emailcím és jelszó páros már használatban van!");

        request.User.Validate();

        _userRepository.Update(request.User);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }
}
