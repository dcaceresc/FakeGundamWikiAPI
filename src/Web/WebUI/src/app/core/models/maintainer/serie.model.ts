import { UniverseDto } from "./universe.model";

export interface SerieDto{
    serieId: number;
    serieName: string;
    universe : UniverseDto;
    isActive: boolean;
    created: Date;
    createdBy: string | null;
    lastModified : Date;
    lastModifiedBy: string | null;
}