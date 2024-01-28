﻿using Application.Administration.Maintainer.Affiliations.Commands.CreateAffiliation;
using Application.Administration.Maintainer.Affiliations.Commands.ToggleAffiliation;
using Application.Administration.Maintainer.Affiliations.Commands.UpdateAffiliation;
using Application.Administration.Maintainer.Affiliations.Queries.GetAffiliantionById;
using Application.Administration.Maintainer.Affiliations.Queries.GetAffiliations;

namespace WebApi.Modules.Maintainer;

public class AffiliationsModule : CarterModule
{
    public override void AddRoutes(IEndpointRouteBuilder app)
    {
        var affiliants = app.MapGroup("/api/affiliants");

        affiliants.MapGet("", GetAffiliants);
        affiliants.MapGet("/{id}", GetAffiliantById);
        affiliants.MapPost("/create", CreateAffiliant);
        affiliants.MapPut("/update/{id}", UpdateAffiliant);
        affiliants.MapDelete("/toggle/{id}", ToggleAffiliant);
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