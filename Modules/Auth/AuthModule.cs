namespace FakeGundamWikiAPI.Modules.Auth;

public class AuthModule() : CarterModule("api/auth")
{
    public override void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPost("login", Login);
        app.MapPost("refreshToken", RefreshToken);
    }

    private async Task<IResult> Login(LoginRequest request, ApplicationDbContext context, AuthenticationService authenticationService, CancellationToken cancellationToken)
    {
        var user = await context.Users
            .Include(u => u.UserRoles)
            .ThenInclude(ur => ur.Role)
            .FirstOrDefaultAsync(u => u.UserName == request.Username && u.Password == request.Password, cancellationToken);

        if (user == null)
            return Results.NotFound();


        var refreshToken = Data.Entities.RefreshToken.Create(user.UserId);

        context.RefreshTokens.Add(refreshToken);

        await context.SaveChangesAsync(cancellationToken);

        var accessToken = authenticationService.CreateAccessToken(user.UserName, user.UserRoles.Select(x => x.Role.RoleName).ToList());

        return Results.Ok(new
        {
            accessToken,
            refreshToken.RefreshTokenValue
        });
    }

    private async Task<IResult> RefreshToken(RefreshTokenRequest request, ApplicationDbContext context, AuthenticationService authenticationService, CancellationToken cancellationToken)
    {
        var refreshToken = await context.RefreshTokens.FirstOrDefaultAsync(x => x.RefreshTokenValue == request.RefreshToken, cancellationToken);

        if (refreshToken is null || refreshToken.RefreshTokenExpiration <= DateTime.Now)
            return Results.BadRequest();

        if (refreshToken.Used)
        {
            var refreshTokens = await context.RefreshTokens.Where(x => x.UserId == refreshToken.UserId).ToListAsync(cancellationToken);

            context.RefreshTokens.RemoveRange(refreshTokens);

            await context.SaveChangesAsync(cancellationToken);

            return Results.Unauthorized();
        }

        refreshToken.MarkAsUsed();


        var user = await context.Users
           .Include(x => x.UserRoles).ThenInclude(x => x.Role)
           .FirstOrDefaultAsync(x => x.UserId == refreshToken.UserId, cancellationToken);

        if (user is null)
            return Results.NotFound();


        var accessToken = authenticationService.CreateAccessToken(user.UserName, user.UserRoles.Select(x => x.Role.RoleName).ToList());

        var newRefreshToken = Data.Entities.RefreshToken.Create(user.UserId);

        context.RefreshTokens.Add(newRefreshToken);

        await context.SaveChangesAsync(cancellationToken);

        return Results.Ok(new
        {
            accessToken,
            refreshToken = newRefreshToken.RefreshTokenValue
        });
    }


}
