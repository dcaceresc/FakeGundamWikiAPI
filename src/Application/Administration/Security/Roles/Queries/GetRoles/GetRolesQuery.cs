namespace Application.Administration.Security.Roles.Queries.GetRoles;
public record GetRolesQuery : IRequest<IList<RoleDto>>;
public class GetRolesQueryHandler(IApplicationDbContext applicationDbContext, IMapper mapper) : IRequestHandler<GetRolesQuery, IList<RoleDto>>
{
    private readonly IApplicationDbContext _applicationDbContext = applicationDbContext;
    private readonly IMapper _mapper = mapper;

    public async Task<IList<RoleDto>> Handle(GetRolesQuery request, CancellationToken cancellationToken)
    {
        return await _applicationDbContext
            .Roles
            .AsNoTracking()
            .ProjectTo<RoleDto>(_mapper.ConfigurationProvider)
            .ToListAsync(cancellationToken);
    }
}