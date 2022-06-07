using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.models
{
    [Table("UserRoles")]
    public class UserRole : IdentityUserRole<string>
    {
        public virtual User User { get; set; }
        public virtual Rol Role { get; set; }
    }
}
