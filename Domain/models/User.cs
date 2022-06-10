using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.models
{
    [Table("Users")]
    public class User : IdentityUser
    {
        [Column("DeparmentId")]
        public int DeparmentId { get; set; }
        [PersonalData]
        [Column("Name")]
        public string Name { get; set; }
        [Column("Lastname")]
        [PersonalData]
        public string Lastname { get; set; }
        [Column("CreatedAt")]
        public DateTime CreatedAt { get; set; }
        [Column("UpdatedAt")]
        public DateTime? UpdatedAt { get; set; }
        [Display(Name = "Recuerdame?")]
        [Column("RememberMe")]
        public bool RememberMe { get; set; }


        public Deparment Deparment { get; set; }
        public ICollection<Comment> Comments { get; set; }
        public ICollection<LogTime> LogTimes { get; set; }

        public virtual ICollection<IdentityUserClaim<string>> Claims { get; set; }
        public virtual ICollection<IdentityUserLogin<string>> Logins { get; set; }
        public virtual ICollection<IdentityUserToken<string>> Tokens { get; set; }
        public virtual ICollection<UserRole> UserRoles { get; set; }
    }
}
