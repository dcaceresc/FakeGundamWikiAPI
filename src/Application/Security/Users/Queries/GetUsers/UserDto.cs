using Application.Security.Roles.Queries.GetRoles;

namespace Application.Security.Users.Queries.GetUsers;
public class UserDto : AuditableEntity
{
    public int UserId { get; set; }
    public string UserName { get; set; } = null!;
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public IList<RoleDto> Roles { get; set; } = null!;
    public bool IsActive { get; set; }

    private class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<User, UserDto>()
                .ForMember(d => d.Roles, opt => opt.MapFrom(s => s.UserRoles.Select(x => new RoleDto
                {
                    RoleId = x.RoleId,
                    RoleName = x.Role.RoleName,
                    IsActive = x.Role.IsActive,
                    CreatedBy = x.Role.CreatedBy,
                    Created = x.Role.Created,
                    LastModifiedBy = x.Role.LastModifiedBy,
                    LastModified = x.Role.LastModified
                }).ToList()));
        }
    }
}
