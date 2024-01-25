namespace Application.Administration.Security.Roles.Queries.GetRoles;
public class RoleDto
{
    public int RoleId { get; set; }
    public string RoleName { get; set; } = default!;
    public bool IsActive { get; set; }

    public class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<Role, RoleDto>();
        }
    }
}
