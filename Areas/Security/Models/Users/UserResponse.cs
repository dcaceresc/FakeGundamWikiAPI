namespace FakeGundamWikiAPI.Areas.Security.Models.Users;

public class UserDto
{
    public int UserId { get; set; }
    public string UserName { get; set; } = null!;
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public List<string> Roles { get; set; } = null!;
    public bool IsActive { get; set; }

    public class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<User, UserDto>()
                .ForMember(d => d.Roles, opt => opt.MapFrom(s => s.UserRoles.Select(x => x.Role.RoleName).ToList()));
        }
    }
}


public class UserVM
{
    public int UserId { get; set; }
    public string UserName { get; set; } = null!;
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public string Password { get; set; } = null!;
    public List<int> RoleIds { get; set; } = null!;

    public class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<User, UserVM>()
                .ForMember(d => d.RoleIds, opt => opt.MapFrom(s => s.UserRoles.Select(x => x.RoleId).ToList()));
        }
    }
}