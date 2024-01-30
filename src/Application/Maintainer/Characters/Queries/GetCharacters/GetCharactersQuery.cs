namespace Application.Maintainer.Characters.Queries.GetCharacters;
public record GetCharactersQuery : IRequest<IList<CharacterDto>>;

public class GetCharactersQueryHandler(IApplicationDbContext context, IMapper mapper) : IRequestHandler<GetCharactersQuery, IList<CharacterDto>>
{
    private readonly IApplicationDbContext _context = context;
    private readonly IMapper _mapper = mapper;

    public async Task<IList<CharacterDto>> Handle(GetCharactersQuery request, CancellationToken cancellationToken)
    {
        return await _context.Characters
            .ProjectTo<CharacterDto>(_mapper.ConfigurationProvider)
            .ToListAsync(cancellationToken);
    }
}

