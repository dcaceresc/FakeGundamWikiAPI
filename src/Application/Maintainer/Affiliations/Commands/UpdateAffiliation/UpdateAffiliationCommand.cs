namespace Application.Maintainer.Affiliations.Commands.UpdateAffiliation;
public record UpdateAffiliationCommand(int AffiliationId, string AffiliationName, string AffiliationPurpose) : IRequest;

public class UpdateAffiliationCommandHandler(IApplicationDbContext context) : IRequestHandler<UpdateAffiliationCommand>
{
    private readonly IApplicationDbContext _context = context;

    public async Task Handle(UpdateAffiliationCommand request, CancellationToken cancellationToken)
    {
        var affiliation = await _context.Affiliations.FindAsync(new object[] { request.AffiliationId }, cancellationToken);

        Guard.Against.NotFound(request.AffiliationId, affiliation);

        affiliation.Update(request.AffiliationName, request.AffiliationPurpose);

        await _context.SaveChangesAsync(cancellationToken);
    }
}

