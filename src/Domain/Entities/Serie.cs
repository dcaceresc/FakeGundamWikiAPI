namespace Domain.Entities;
public class Serie : AuditableEntity
{
    public int SerieId { get; set; }
    public string SerieName { get; set; } = null!;
    public int UniverseId { get; set; }
    public Universe Universe { get; set; } = null!;
    public bool IsActive { get; set; }
}
