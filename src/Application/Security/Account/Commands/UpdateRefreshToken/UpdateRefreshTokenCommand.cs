namespace Application.Security.Account.Commands.UpdateRefreshToken;
public record UpdateRefreshTokenCommand(string RefreshToken) : IRequest<UpdateRefreshTokenCommandResponse>;
public class UpdateRefreshTokenCommandHandler(IApplicationDbContext applicationDbContext, IAuthenticationService authenticationService) :
    IRequestHandler<UpdateRefreshTokenCommand, UpdateRefreshTokenCommandResponse>
{
    private readonly IApplicationDbContext _applicationDbContext = applicationDbContext;
    private readonly IAuthenticationService _authenticationService = authenticationService;

    public async Task<UpdateRefreshTokenCommandResponse> Handle(UpdateRefreshTokenCommand request, CancellationToken cancellationToken)
    {
        var refreshToken = await _applicationDbContext.RefreshTokens.FirstOrDefaultAsync(x => x.RefreshTokenValue == request.RefreshToken, cancellationToken);

        if (refreshToken is null || refreshToken.RefreshTokenExpiration <= DateTime.Now)
        {
            throw new ForbiddenAccessException();
        }

        if (refreshToken.Used)
        {
            var refreshTokens = await _applicationDbContext.RefreshTokens.Where(x => x.UserId == refreshToken.UserId).ToListAsync(cancellationToken);

            _applicationDbContext.RefreshTokens.RemoveRange(refreshTokens);

            await _applicationDbContext.SaveChangesAsync(cancellationToken);

            throw new ForbiddenAccessException();
        }

        refreshToken.MarkAsUsed();

        var user = await _applicationDbContext.Users
            .Include(x => x.UserRoles).ThenInclude(x => x.Role).FirstOrDefaultAsync(x => x.UserId == refreshToken.UserId, cancellationToken) ?? throw new ForbiddenAccessException();

        var accessToken = _authenticationService.CreateAccessToken(user.UserName, user.UserRoles.Select(x => x.Role.RoleName).ToList());

        var newRefreshToken = RefreshToken.Create(user.UserId);

        _applicationDbContext.RefreshTokens.Add(newRefreshToken);

        await _applicationDbContext.SaveChangesAsync(cancellationToken);

        return new UpdateRefreshTokenCommandResponse()
        {
            AccessToken = accessToken,
            RefreshToken = newRefreshToken.RefreshTokenValue
        };
    }
}