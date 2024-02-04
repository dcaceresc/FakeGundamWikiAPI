export interface UniverseDto {
    universeId: number;
    universeName: string;
    isActive: boolean;
    created: Date;
    createdBy: string | null;
    lastModified : Date;
    lastModifiedBy: string | null;
}