namespace Application.Administration.Security.Users.Queries.GetUsers;
public record GetUsersQuery : IRequest<IList<UserDto>>;


public class GetUsersQueryHandler(IApplicationDbContext applicationDbContext, IMapper mapper) : IRequestHandler<GetUsersQuery, IList<UserDto>>
{
    private readonly IApplicationDbContext _applicationDbContext = applicationDbContext;
    private readonly IMapper _mapper = mapper;

    public async Task<IList<UserDto>> Handle(GetUsersQuery request, CancellationToken cancellationToken)
    {
        return await _applicationDbContext
            .Users
            .AsNoTracking()
            .Include(x => x.UserRoles)
            .ThenInclude(x => x.Role)
            .ProjectTo<UserDto>(_mapper.ConfigurationProvider)
            .ToListAsync(cancellationToken);
    }
}