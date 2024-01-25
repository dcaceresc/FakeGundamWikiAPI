namespace Application.Administration.Security.Users.Queries.GetUserById;
public class UserVM
{
    public int UserId { get; set; }
    public string UserName { get; set; } = default!;
    public string FirstName { get; set; } = default!;
    public string LastName { get; set; } = default!;
    public IList<int> RoleIds { get; set; } = default!;

    private class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<User, UserVM>()
                .ForMember(s => s.RoleIds, opt => opt.MapFrom(s => s.UserRoles.Select(x => x.RoleId).ToList()));
        }
    }
}
