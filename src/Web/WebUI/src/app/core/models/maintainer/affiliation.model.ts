export interface AffiliationDto {
    affiliationId: number;
    affiliationName: string;
    affiliationPurpose: string;
    isActive: boolean;
    created: Date;
    createdBy: string | null;
    lastModified : Date;
    lastModifiedBy: string | null;
}