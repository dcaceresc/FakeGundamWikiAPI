
namespace FakeGundamWikiAPI.Modules.Roles;

public class RolesModule() : CarterModule("api/roles")
{
    public override void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("", GetRoles);
        app.MapGet("{id:int}", GetRoleById);
        app.MapPost("", CreateRole);
        app.MapPut("", UpdateRole);
        app.MapDelete("{id:int}", ToggleRole);
    }

    public async Task<IResult> GetRoles(ApplicationDbContext context, IMapper mapper, CancellationToken cancellationToken)
    {
        var roles = await context.Roles
            .ProjectTo<RoleResponse>(mapper.ConfigurationProvider)
            .ToListAsync(cancellationToken);

        return Results.Ok(roles);
    }

    public async Task<IResult> GetRoleById(int id, ApplicationDbContext context, IMapper mapper, CancellationToken cancellationToken)
    {
        var role = await context.Roles
            .ProjectTo<RoleResponse>(mapper.ConfigurationProvider)
            .FirstOrDefaultAsync(r => r.RoleId == id, cancellationToken);

        if (role == null)
            return Results.NotFound();

        return Results.Ok(role);
    }

    public async Task<IResult> CreateRole(CreateRoleRequest request, ApplicationDbContext context, CancellationToken cancellationToken)
    {
        var role = Role.Create(request.RoleName);

        context.Roles.Add(role);

        await context.SaveChangesAsync(cancellationToken);

        return Results.Created($"/api/roles/{role.RoleId}", role);
    }

    public async Task<IResult> UpdateRole(int id, UpdateRoleRequest request, ApplicationDbContext context, CancellationToken cancellationToken)
    {
        if (id != request.RoleId)
            return Results.BadRequest("The role id in the request does not match the id in the route");


        var role = await context.Roles.FindAsync(new object[] { id }, cancellationToken);

        if (role == null)
            return Results.NotFound();

        role.Update(request.RoleName);

        await context.SaveChangesAsync(cancellationToken);

        return Results.Ok(role);
    }

    public async Task<IResult> ToggleRole(int id, ApplicationDbContext context, CancellationToken cancellationToken)
    {
        var role = await context.Roles.FindAsync(new object[] { id }, cancellationToken);

        if (role == null)
            return Results.NotFound();

        role.ToggleActive();

        await context.SaveChangesAsync(cancellationToken);

        return Results.NoContent();
    }
}
