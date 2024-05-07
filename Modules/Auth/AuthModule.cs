
namespace FakeGundamWikiAPI.Modules.Auth;

public class AuthModule() : CarterModule("api/auth")
{
    public override void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPost("login", Login);
    }

    private async Task<IResult> Login(LoginRequest request, ApplicationDbContext context, AuthenticationService authenticationService, CancellationToken cancellationToken)
    {
        var user = await context.Users
            .Include(u => u.UserRoles)
            .ThenInclude(ur => ur.Role)
            .FirstOrDefaultAsync(u => u.UserName == request.Username, cancellationToken);

        if (user == null)
            return Results.NotFound();

        if (user.Password == request.Password)
            return Results.Unauthorized();

        var token = authenticationService.CreateAccessToken(user.UserName, user.UserRoles.Select(x => x.Role.RoleName).ToList());

        return Results.Ok(token);
    }
}
