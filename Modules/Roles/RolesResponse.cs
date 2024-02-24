namespace FakeGundamWikiAPI.Modules.Roles;

public class RoleResponse : AuditableEntity
{
    public int RoleId { get; set; }
    public string RoleName { get; set; } = null!;
    public bool IsActive { get; set; }

    public class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<Role, RoleResponse>();
        }
    }
}
