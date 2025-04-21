namespace FakeGundamWikiAPI.Modules.Users;

public class UsersModule() : CarterModule()
{
    public override void AddRoutes(IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("api/users")
            .RequireAuthorization(new AuthorizeAttribute
            {
                AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme
            });

        group.MapGet("", GetUsers);
        group.MapGet("{id:int}", GetUserById);
        group.MapPost("", CreateUser);
        group.MapPut("{id:int}", UpdateUser);
        group.MapDelete("{id:int}", ToggleUser);
    }

    private async Task<IResult> GetUsers(ApplicationDbContext context, IMapper mapper, CancellationToken cancellationToken)
    {
        var users = await context.Users
            .ProjectTo<UserResponse>(mapper.ConfigurationProvider)
            .ToListAsync(cancellationToken);

        return Results.Ok(users);
    }

    private async Task<IResult> GetUserById(int id, ApplicationDbContext context, IMapper mapper, CancellationToken cancellationToken)
    {
        var user = await context.Users
            .ProjectTo<UserResponse>(mapper.ConfigurationProvider)
            .FirstOrDefaultAsync(x => x.UserId == id, cancellationToken);

        if (user == null)
            return Results.NotFound();

        return Results.Ok(user);
    }

    private async Task<IResult> CreateUser([FromBody] CreateUserRequest request, ApplicationDbContext context, CancellationToken cancellationToken)
    {
        var user = User.Create(request.UserName, request.FirstName, request.LastName, request.Password);

        context.Users.Add(user);

        await context.SaveChangesAsync(cancellationToken);

        foreach (var item in request.RoleIds)
        {
            var userRole = user.AssignRole(item);

            context.UserRoles.Add(userRole);
        }

        await context.SaveChangesAsync(cancellationToken);

        return Results.Created($"api/users/{user.UserId}", user);
    }

    private async Task<IResult> UpdateUser(int id, [FromBody] UpdateUserRequest request, ApplicationDbContext context, CancellationToken cancellationToken)
    {
        if (request.UserId != id)
            return Results.BadRequest("The user id in the request does not match the id in the route");

        var user = await context.Users.FindAsync([id], cancellationToken);

        if (user == null)
            return Results.NotFound();

        user.Update(request.UserName, request.FirstName, request.LastName, request.Password);

        var oldUserRoles = await context.UserRoles.Where(x => x.UserId == request.UserId).ToListAsync(cancellationToken);

        foreach (var item in request.RoleIds)
        {
            var exitingUserRole = oldUserRoles.FirstOrDefault(x => x.RoleId == item);

            if (exitingUserRole is null)
            {
                var userRole = user.AssignRole(item);

                context.UserRoles.Add(userRole);
            }
            else
            {
                exitingUserRole.LastModified = DateTime.Now;
            }
        }

        foreach (var userRole in oldUserRoles)
        {
            if (!request.RoleIds.Contains(userRole.RoleId))
            {
                context.UserRoles.Remove(userRole);
            }
        }

        await context.SaveChangesAsync(cancellationToken);

        return Results.Ok(user);
    }

    private async Task<IResult> ToggleUser(int id, ApplicationDbContext context, CancellationToken cancellationToken)
    {
        var user = await context.Users.FindAsync([id], cancellationToken);

        if (user == null)
            return Results.NotFound();

        user.ToggleActive();

        await context.SaveChangesAsync(cancellationToken);

        return Results.NoContent();
    }
}
