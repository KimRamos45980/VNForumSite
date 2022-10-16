using Microsoft.AspNetCore.Identity;

namespace VNForumSite.Models
{
    // How to add application user class/to DbContext
    // https://learn.microsoft.com/en-us/aspnet/core/security/authentication/customize-identity-model?view=aspnetcore-6.0#custom-user-data
    public class ApplicationUser : IdentityUser
    {
        public string? CustomTag { get; set; }

    }

    public class UserTags
    {
        public int Id { get; set; }
        public string Tag { get; set; }
    }
}
