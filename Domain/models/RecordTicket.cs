using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.models
{
    [Table("records_tickets")]
    public class RecordTicket
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Column("record_ticket_id")]
        public int RecordTicketId { get; set; }
        [Column("ticket_id")]
        public string TicketId { get; set; }
        [Column("description")]
        public string Description { get; set; }
        [Column("created_at")]
        public DateTime CreatedAt { get; set; }
        [Column("updated_at")]
        public DateTime? UpdateddAt { get; set; }
        public Ticket Ticket { get; set; }
    }
}
