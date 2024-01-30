namespace Application.Maintainer.Manufacturers.Commands.UpdateManufacturer;
public record UpdateManufacturerCommand(int ManufacturerId, string ManufacturerName) : IRequest;

public class UpdateManufacturerCommandHandler(IApplicationDbContext context) : IRequestHandler<UpdateManufacturerCommand>
{
    private readonly IApplicationDbContext _context = context;

    public async Task Handle(UpdateManufacturerCommand request, CancellationToken cancellationToken)
    {
        var manufacturer = await _context.Manufacturers.FindAsync(new object[] { request.ManufacturerId }, cancellationToken);

        Guard.Against.NotFound(request.ManufacturerId, manufacturer);

        manufacturer.Update(request.ManufacturerName);

        await _context.SaveChangesAsync(cancellationToken);
    }
}

