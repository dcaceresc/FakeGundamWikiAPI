using Application.Security.Roles.Queries.GetRoles;

namespace Application.Security.Users.Queries.GetUserById;
public class UserVM : AuditableEntity
{
    public int UserId { get; set; }
    public string UserName { get; set; } = default!;
    public string FirstName { get; set; } = default!;
    public string LastName { get; set; } = default!;
    public IList<RoleDto> Roles { get; set; } = default!;

    private class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<User, UserVM>()
                .ForMember(s => s.Roles, opt => opt.MapFrom(s => s.UserRoles.Select(x => new RoleDto
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
