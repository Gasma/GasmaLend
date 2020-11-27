using Microsoft.AspNetCore.Identity;

namespace gasmaTools.Domain.Entities
{
    public class AppUser : IdentityUser
    {
        public string FullName { get; private set; }

        public AppUser(string userName, string email, string fullName)
        {
            this.UserName = userName;
            this.Email = email;
            this.FullName = fullName;
        }
    }
}
