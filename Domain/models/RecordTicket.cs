using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.models
{
    [Table("RecordsTickets")]
    public class RecordTicket
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("RecordTicketId")]
        public int RecordTicketId { get; set; }
        [Column("TicketId")]
        public int TicketId { get; set; }
        [Column("Description")]
        public string Description { get; set; }
        [Column("CreatedAt")]
        public DateTime CreatedAt { get; set; }
        [Column("UpdatedAt")]
        public DateTime? UpdatedAt { get; set; }
        public Ticket Ticket { get; set; }
    }
}
