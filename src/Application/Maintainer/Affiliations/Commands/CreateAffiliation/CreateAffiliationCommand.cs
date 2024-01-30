namespace Application.Maintainer.Affiliations.Commands.CreateAffiliation;
public record CreateAffiliationCommand(string AffiliationName, string AffiliationPurpuse) : IRequest<int>;

public class CreateAffiliationCommandHandler(IApplicationDbContext context) : IRequestHandler<CreateAffiliationCommand, int>
{
    private readonly IApplicationDbContext _context = context;

    public async Task<int> Handle(CreateAffiliationCommand request, CancellationToken cancellationToken)
    {
        var affiliation = Affiliation.Create(request.AffiliationName, request.AffiliationPurpuse);

        _context.Affiliations.Add(affiliation);

        await _context.SaveChangesAsync(cancellationToken);

        return affiliation.AffiliationId;
    }
}