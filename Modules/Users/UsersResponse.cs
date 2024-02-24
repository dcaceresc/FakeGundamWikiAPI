using FakeGundamWikiAPI.Modules.Roles;

namespace FakeGundamWikiAPI.Modules.Users;

public class UserResponse : AuditableEntity
{
    public int UserId { get; set; }
    public string UserName { get; set; } = null!;
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public string Password { get; set; } = null!;
    public IList<RoleResponse> Roles { get; set; } = null!;
    public bool IsActive { get; set; }

    public class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<User, UserResponse>()
                 .ForMember(d => d.Roles, opt => opt.MapFrom(s => s.UserRoles.Select(x => new RoleResponse
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
