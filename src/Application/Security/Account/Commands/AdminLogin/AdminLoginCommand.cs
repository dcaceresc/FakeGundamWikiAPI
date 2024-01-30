namespace Application.Security.Account.Commands.AdminLogin;

public record AdminLoginCommand(string UserName, string Password, string Supplanted) : IRequest<bool>;

public class AdminLoginRequestCommandHandler(IMediator mediator) : IRequestHandler<AdminLoginCommand, bool>
{
    private readonly IMediator _mediator = mediator;

    public async Task<bool> Handle(AdminLoginCommand request, CancellationToken cancellationToken)
    {
        return true;
    }
}
