using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.models
{
    [Table("log_time")]
    public class LogTime
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Column("log_time_id")]
        public int LogTimeId { get; set; }
        [Column("user_id")]
        public int UserId { get; set; }
        [Column("ticket_id")]
        public int TicketId { get; set; }
        [Column("description")]
        public string Description { get; set; }
        [Column("date")]
        public DateTime Date { get; set; }
        [Column("hours")]
        public decimal Hours { get; set; }
        
        public User User { get; set; }
        public Ticket Ticket { get; set; }
    }
}
