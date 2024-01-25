namespace Application.Administration.Security.Roles.Queries.GetRoleById;
public record GetRoleByIdQuery(int RoleId) : IRequest<RoleVM>;

public class GetRoleByIdQueryHandler(IApplicationDbContext applicationDbContext, IMapper mapper) : IRequestHandler<GetRoleByIdQuery, RoleVM>
{
    private readonly IApplicationDbContext _applicationDbContext = applicationDbContext;
    private readonly IMapper _mapper = mapper;

    public async Task<RoleVM> Handle(GetRoleByIdQuery request, CancellationToken cancellationToken)
    {
        var role = await _applicationDbContext
            .Roles
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.RoleId == request.RoleId, cancellationToken);

        Guard.Against.NotFound(request.RoleId, role);

        return _mapper.Map<RoleVM>(role);
    }
}