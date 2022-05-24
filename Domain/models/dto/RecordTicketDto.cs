namespace Domain.models.dto
{
    public class RecordTicketDto
    {
        public int RecordTicketId { get; set; }
        public string TicketId { get; set; }
        public string Description { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public TicketDto Ticket { get; set; }
    }
}