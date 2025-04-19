namespace FakeGundamWikiAPI.Common;

public static class SiteConfig
{
    public static bool SiteStatus { get; set; }
    public static string SiteUrl { get; set; } = null!;
    public static string SuperAdminUserName { get; set; } = null!;
    public static string SuperAdminPassword { get; set; } = null!;
}
