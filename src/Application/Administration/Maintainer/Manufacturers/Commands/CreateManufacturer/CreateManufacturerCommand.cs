namespace Application.Administration.Maintainer.Manufacturers.Commands.CreateManufacturer;
public record CreateManufacturerCommand(string ManufacturerName) : IRequest<int>;

public class CreateManufacturerCommandHandler(IApplicationDbContext context) : IRequestHandler<CreateManufacturerCommand, int>
{
    private readonly IApplicationDbContext _context = context;

    public async Task<int> Handle(CreateManufacturerCommand request, CancellationToken cancellationToken)
    {
        var manufacturer = Manufacturer.Create(request.ManufacturerName);

        _context.Manufacturers.Add(manufacturer);

        await _context.SaveChangesAsync(cancellationToken);

        return manufacturer.ManufacturerId;
    }
}
