using Microsoft.AspNetCore.Identity;

namespace secure_programming.Models
{
    public class RoleEdit
    {
        //creates class to edit role settings for users
        public IdentityRole Role { get; set; }
        public IEnumerable<IdentityUser> Members { get; set; }
        public IEnumerable<IdentityUser> NonMembers { get; set; }
    }
}