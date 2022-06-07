using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.models
{
    [Table("Roles")]
    public class Rol : IdentityRole
    {
        public Rol() : base()
        {
        }

        public Rol(string roleName)
        {
            Name = roleName;
        }
        public virtual ICollection<UserRole> UserRoles { get; set; }
    }
}
