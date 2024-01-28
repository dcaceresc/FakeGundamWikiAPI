namespace Application.Administration.Maintainer.Affiliations.Commands.ToggleAffiliation;
public record ToggleAffiliationCommand(int AffiliationId) : IRequest;

public class ToggleAffiliationCommandHandler(IApplicationDbContext context) : IRequestHandler<ToggleAffiliationCommand>
{
    private readonly IApplicationDbContext _context = context;

    public async Task Handle(ToggleAffiliationCommand request, CancellationToken cancellationToken)
    {
        var affiliation = await _context.Affiliations.FindAsync(new object[] { request.AffiliationId }, cancellationToken);

        Guard.Against.NotFound(request.AffiliationId, affiliation);

        affiliation.ToggleActive();

        await _context.SaveChangesAsync(cancellationToken);

    }
}
