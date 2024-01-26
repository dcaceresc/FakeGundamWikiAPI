﻿namespace Application.Administration.Maintainer.Universes.Queries.GetUniverses;

public class UniverseDto
{
    public int UniverseId { get; set; }
    public string UniverseName { get; set; } = null!;
    public bool IsActive { get; set; }

    public class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<Universe, UniverseDto>();
        }
    }
}