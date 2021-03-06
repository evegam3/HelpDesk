namespace Domain.models.dto
{
    public class StatusDto
    {
        public int StatusId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public List<TicketDto> Tickets { get; set; }
    }
}
