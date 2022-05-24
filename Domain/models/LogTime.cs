using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.models
{
    [Table("LogTime")]
    public class LogTime
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("LogTimeId")]
        public int LogTimeId { get; set; }
        [Column("UserId")]
        public string UserId { get; set; }
        [Column("TicketId")]
        public int TicketId { get; set; }
        [Column("Description")]
        public string Description { get; set; }
        [Column("Date")]
        public DateTime Date { get; set; }
        [Column("Hours")]
        public decimal Hours { get; set; }
        
        public User User { get; set; }
        public Ticket Ticket { get; set; }
    }
}
