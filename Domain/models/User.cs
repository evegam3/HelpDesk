using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.models
{
    [Table("users")]
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
        public ICollection<Ticket> AssignedTickets { get; set; }
        public ICollection<Ticket> ReportedTickets { get; set; }
        public ICollection<Comment> Comments { get; set; }
        public ICollection<LogTime> LogTimes { get; set; }
    }
}
