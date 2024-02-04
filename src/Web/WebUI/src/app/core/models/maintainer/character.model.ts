import { AffiliationDto } from "./affiliation.model";

export interface CharacterDto {
    characterId: number;
    characterAliases: string;
    characterName: string;
    characterClassification: string;
    characterBirthDate: string;
    characterGenderId: number;
    affiliations : AffiliationDto[];
}