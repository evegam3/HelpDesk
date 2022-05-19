namespace Domain.models.dto
{
    public class PriorityDto
    {
        public int PriorityId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdateddAt { get; set; }
        public List<TicketDto> Tickets { get; set; }
    }
}
