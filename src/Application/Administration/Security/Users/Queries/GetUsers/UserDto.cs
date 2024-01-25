namespace Application.Administration.Security.Users.Queries.GetUsers;
public class UserDto
{
    public int UserId { get; set; }
    public string UserName { get; set; } = null!;
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public IList<string> RoleNames { get; set; } = null!;
    public bool IsActive { get; set; }

    private class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<User, UserDto>()
                .ForMember(d => d.RoleNames, opt => opt.MapFrom(s => s.UserRoles.Select(x => x.Role.RoleName).ToList()));
        }
    }
}
