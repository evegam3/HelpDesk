using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.models
{
    [Table("users")]
    public class User
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Column("user_id")]
        public int UserId { get; set; }
        [Column("deparment_id")]
        public int DeparmentId { get; set; }
        [Column("name")]
        public string Name { get; set; }
        [Column("lastname")]
        public string Lastname { get; set; }
        [Column("password")]
        public string Password { get; set; }
        [Column("email")]
        public string Email { get; set; }
        [Column("created_at")]
        public DateTime CreatedAt { get; set; }
        [Column("updated_at")]
        public DateTime? UpdateddAt { get; set; }

        public Deparment Deparment { get; set; }
        public ICollection<RolUser> RolUsers { get; set; }
        public ICollection<Ticket> AssignedTickets { get; set; }
        public ICollection<Ticket> ReportedTickets { get; set; }
        public ICollection<Comment> Comments { get; set; }
        public ICollection<LogTime> LogTimes { get; set; }
    }
}
