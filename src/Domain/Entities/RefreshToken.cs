namespace Domain.Entities;
public class RefreshToken : AuditableEntity
{
    private RefreshToken(int userId)
    {
        RefreshTokenValue = Guid.NewGuid().ToString("N");
        RefreshTokenExpiration = DateTime.Now.AddDays(7);
        UserId = userId;
        Used = false;
    }


    public int RefreshTokenId { get; private set; }
    public string RefreshTokenValue { get; private set; } = null!;
    public DateTime RefreshTokenExpiration { get; private set; }
    public bool Used { get; private set; }
    public int UserId { get; private set; }
    public User User { get; private set; } = null!;


    public static RefreshToken Create(int userId)
    {
        return new RefreshToken(userId);
    }


    public void MarkAsUsed()
    {
        Used = true;
    }
}
