using Microsoft.AspNetCore.Identity;

namespace VNForumSite.Models
{
    // How to add application user class/to DbContext
    // https://learn.microsoft.com/en-us/aspnet/core/security/authentication/customize-identity-model?view=aspnetcore-6.0#custom-user-data
    public class ApplicationUser : IdentityUser
    {
        // User Generated Tag(s) that user has selected to describe themself as
        // *NOTE* Search if multiple selected tags can be listed in one property
        // *TODO* Allow UserTags class to fill in the CustomTag property
        public string? CustomTag { get; set; }

    }

    /// <summary>
    /// Allow users to create their own tags/assign themselves tags already created
    /// </summary>
    public class UserTags
    {
        public int Id { get; set; }
        public string? Tag { get; set; }
    }
}
