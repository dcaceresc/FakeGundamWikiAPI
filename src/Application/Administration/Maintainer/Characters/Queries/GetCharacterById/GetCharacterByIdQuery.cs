namespace Application.Administration.Maintainer.Characters.Queries.GetCharacterById;
public record GetCharacterByIdQuery(int CharacterId) : IRequest<CharacterVM>;

public class GetCharacterByIdQueryHandler(IApplicationDbContext context, IMapper mapper) : IRequestHandler<GetCharacterByIdQuery, CharacterVM>
{
    private readonly IApplicationDbContext _context = context;
    private readonly IMapper _mapper = mapper;

    public async Task<CharacterVM> Handle(GetCharacterByIdQuery request, CancellationToken cancellationToken)
    {
        var character = await _context.Characters
            .ProjectTo<CharacterVM>(_mapper.ConfigurationProvider)
            .FirstOrDefaultAsync(x => x.CharacterId == request.CharacterId, cancellationToken);

        Guard.Against.NotFound(request.CharacterId, character);

        return character;
    }
}

