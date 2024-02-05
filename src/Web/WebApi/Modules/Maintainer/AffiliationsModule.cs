﻿using Application.Maintainer.Affiliations.Commands.CreateAffiliation;
using Application.Maintainer.Affiliations.Commands.ToggleAffiliation;
using Application.Maintainer.Affiliations.Commands.UpdateAffiliation;
using Application.Maintainer.Affiliations.Queries.GetAffiliantionById;
using Application.Maintainer.Affiliations.Queries.GetAffiliations;

namespace WebApi.Modules.Maintainer;

public class AffiliationsModule : CarterModule
{
    public AffiliationsModule() : base("api/affiliations")
    {

    }

    public override void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("", GetAffiliants);
        app.MapGet("/{id}", GetAffiliantById);
        app.MapPost("", CreateAffiliant);
        app.MapPut("/{id}", UpdateAffiliant);
        app.MapDelete("/{id}", ToggleAffiliant);
    }

    private async Task<IResult> GetAffiliants(ISender sender)
    {
        return Results.Ok(await sender.Send(new GetAffiliationsQuery()));
    }

    private async Task<IResult> GetAffiliantById(int id, ISender sender)
    {
        return Results.Ok(await sender.Send(new GetAffiliantionByIdQuery(id)));
    }

    private async Task<IResult> CreateAffiliant(CreateAffiliationCommand command, ISender sender)
    {
        await sender.Send(command);

        return Results.Ok();
    }

    private async Task<IResult> UpdateAffiliant(int id, UpdateAffiliationCommand command, ISender sender)
    {
        if (id != command.AffiliationId)
            return Results.BadRequest();

        await sender.Send(command);

        return Results.Ok();
    }

    private async Task<IResult> ToggleAffiliant(int id, ISender sender)
    {
        await sender.Send(new ToggleAffiliationCommand(id));

        return Results.Ok();
    }
}
