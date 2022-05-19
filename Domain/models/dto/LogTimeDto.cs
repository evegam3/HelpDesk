namespace Domain.models.dto
{
    public class LogTimeDto
    {
        public int LogTimeId { get; set; }
        public int UserId { get; set; }
        public int TicketId { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public decimal Hours { get; set; }

        public UserDto User { get; set; }
        public TicketDto Ticket { get; set; }
    }
}