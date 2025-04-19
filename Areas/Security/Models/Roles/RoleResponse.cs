namespace FakeGundamWikiAPI.Areas.Security.Models.Roles;

public class RoleDto
{
    public int RoleId { get; set; }
    public string RoleName { get; set; } = null!;
    public bool IsActive { get; set; }

    public class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<Role, RoleDto>();
        }
    }
}

public class RoleVM
{
    public int RoleId { get; set; }
    public string RoleName { get; set; } = null!;
    public bool IsActive { get; set; }
    public class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<Role, RoleVM>();
        }
    }
}
