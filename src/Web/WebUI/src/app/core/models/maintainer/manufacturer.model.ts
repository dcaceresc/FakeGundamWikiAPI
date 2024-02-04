export interface ManufacturerDto {
    manufacturerId: number;
    manufacturerName: string;
    isActive: string;
    created: Date;
    createdBy: string | null;
    lastModified : Date;
    lastModifiedBy: string | null;
}