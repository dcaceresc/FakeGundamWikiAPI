namespace Application.Administration.Security.Account.Commands.UserLogin;

public record UserLoginCommand(string UserName, string Password) : IRequest<bool>;

public class LoginRequestCommandHandler(IMediator mediator) : IRequestHandler<UserLoginCommand, bool>
{
    private readonly IMediator _mediator = mediator;

    public async Task<bool> Handle(UserLoginCommand request, CancellationToken cancellationToken)
    {
        return true;
    }
}