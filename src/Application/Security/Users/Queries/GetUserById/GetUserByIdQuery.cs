namespace Application.Security.Users.Queries.GetUserById;
public record GetUserByIdQuery(int UserId) : IRequest<UserVM>;
public class GetUserByIdQueryHandler(IApplicationDbContext applicationDbContext, IMapper mapper) : IRequestHandler<GetUserByIdQuery, UserVM>
{
    private readonly IApplicationDbContext _applicationDbContext = applicationDbContext;
    private readonly IMapper _mapper = mapper;

    public async Task<UserVM> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
    {
        var user = await _applicationDbContext
            .Users
            .Include(x => x.UserRoles)
            .ThenInclude(x => x.Role)
            .AsNoTracking()
            .ProjectTo<UserVM>(_mapper.ConfigurationProvider)
            .FirstOrDefaultAsync(x => x.UserId == request.UserId, cancellationToken);

        Guard.Against.NotFound(request.UserId, user);


        return user;
    }
}