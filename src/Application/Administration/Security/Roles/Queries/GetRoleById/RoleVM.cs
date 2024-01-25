namespace Application.Administration.Security.Roles.Queries.GetRoleById;

public class RoleVM
{
    public int RoleId { get; set; }
    public string RoleName { get; set; } = null!;

    public class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<Role, RoleVM>();
        }
    }
}