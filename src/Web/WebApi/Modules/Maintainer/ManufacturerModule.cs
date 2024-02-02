using Application.Maintainer.Manufacturers.Commands.CreateManufacturer;
using Application.Maintainer.Manufacturers.Commands.ToggleManufacturer;
using Application.Maintainer.Manufacturers.Commands.UpdateManufacturer;
using Application.Maintainer.Manufacturers.Queries.GetManufacturerById;
using Application.Maintainer.Manufacturers.Queries.GetManufacturers;

namespace WebApi.Modules.Maintainer;

public class ManufacturerModule : CarterModule
{
    public override void AddRoutes(IEndpointRouteBuilder app)
    {
        var manufacturers = app.MapGroup("/api/manufacturers");

        manufacturers.MapGet("", GetManufacturers);
        manufacturers.MapGet("/{id}", GetManufacturerById);
        manufacturers.MapPost("", CreateManufacturer);
        manufacturers.MapPut("/{id}", UpdateManufacturer);
        manufacturers.MapDelete("/{id}", ToggleManufacturer);
    }

    private async Task<IResult> GetManufacturers(ISender sender)
    {
        return Results.Ok(await sender.Send(new GetManufacturersQuery()));
    }

    private async Task<IResult> GetManufacturerById(int id, ISender sender)
    {
        return Results.Ok(await sender.Send(new GetManufacturerByIdQuery(id)));
    }

    private async Task<IResult> CreateManufacturer(CreateManufacturerCommand command, ISender sender)
    {
        return Results.Ok(await sender.Send(command));
    }

    private async Task<IResult> UpdateManufacturer(int id, UpdateManufacturerCommand command, ISender sender)
    {
        if (id != command.ManufacturerId)
            return Results.BadRequest();

        await sender.Send(command);

        return Results.NoContent();
    }

    private async Task<IResult> ToggleManufacturer(int id, ISender sender)
    {
        await sender.Send(new ToggleManufacturerCommand(id));

        return Results.NoContent();
    }
}
