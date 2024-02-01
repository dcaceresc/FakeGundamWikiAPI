﻿namespace Application.Maintainer.Affiliations.Queries.GetAffiliations;

public class AffiliationDto : AuditableEntity
{
    public int AffiliationId { get; set; }
    public string AffiliationName { get; set; } = string.Empty;
    public string AffiliationPurpose { get; set; } = string.Empty;
    public bool IsActive { get; set; }

    public class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<Affiliation, AffiliationDto>();
        }
    }
}