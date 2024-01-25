namespace Application.Administration.Security.Account.Commands.CreateTokens;
public record CreateTokensCommand(string UserName) : IRequest<CreateTokensCommandResponse>;

public class CreateTokenCommandHandler(IApplicationDbContext applicationDbContext, IAuthenticationService authenticationService) :
    IRequestHandler<CreateTokensCommand, CreateTokensCommandResponse>
{
    private readonly IApplicationDbContext _applicationDbContext = applicationDbContext;
    private readonly IAuthenticationService _authenticationService = authenticationService;

    public async Task<CreateTokensCommandResponse> Handle(CreateTokensCommand request, CancellationToken cancellationToken)
    {

        var user = await _applicationDbContext.Users.Where(x => x.UserName == request.UserName).FirstOrDefaultAsync(cancellationToken);

        Guard.Against.NotFound(request.UserName, user);


        var refreshToken = RefreshToken.Create(user.UserId);

        _applicationDbContext.RefreshTokens.Add(refreshToken);

        await _applicationDbContext.SaveChangesAsync(cancellationToken);


        var roles = await _applicationDbContext.Users
            .Include(x => x.UserRoles)
            .Where(x => x.UserName == request.UserName).Select(x => x.UserRoles.Select(x => x.Role.RoleName).First())
            .ToListAsync(cancellationToken);


        return new CreateTokensCommandResponse()
        {
            AccessToken = _authenticationService.CreateAccessToken(request.UserName, roles),
            RefreshToken = refreshToken.RefreshTokenValue
        };
    }
}