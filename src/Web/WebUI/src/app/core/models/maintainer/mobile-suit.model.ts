import { CharacterDto } from "./character.model";
import { ManufacturerDto } from "./manufacturer.model";
import { SerieDto } from "./serie.model";

export interface MobileSuitDto { 
    mobileSuitId: number;
    mobileSuitName: string;
    mobileSuitUnitType: string;
    mobileSuitFirstSeen: string;
    mobileSuitLastSeen: string;
    manufacturer : ManufacturerDto;
    serie : SerieDto;
    mobileSuitPilots : CharacterDto[];
    isActive: boolean;
    created: Date;
    createdBy: string | null;
    lastModified : Date;
    lastModifiedBy: string | null;
}

export interface MobileSuitVM{
    mobileSuitId: number;
    mobileSuitName: string;
    mobileSuitUnitType: string;
    mobileSuitFirstSeen: string;
    mobileSuitLastSeen: string;
    manufacturer : ManufacturerDto;
    serie : SerieDto;
    mobileSuitPilots : CharacterDto[];
    isActive: boolean;
    created: Date;
    createdBy: string | null;
    lastModified : Date;
    lastModifiedBy: string | null;
}