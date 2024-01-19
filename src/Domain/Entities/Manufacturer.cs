using Domain.Common;

namespace Domain.Entities;
public class Manufacturer : AuditableEntity
{
    public int id { get; set; }
    public string name { get; set; } = null!;
    public bool active { get; set; }
}
