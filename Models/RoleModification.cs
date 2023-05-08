using System.ComponentModel.DataAnnotations;

namespace secure_programming.Models
{
    public class RoleModification
    {
        //creates class for modification to the roles
        [Required]
        public string RoleName { get; set; }

        public string RoleId { get; set; }

        public string[]? AddIds { get; set; }

        public string[]? DeleteIds { get; set; }
    }
}
