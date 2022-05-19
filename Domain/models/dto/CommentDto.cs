namespace Domain.models.dto
{
    public class CommentDto
    {
        public int CommentId { get; set; }
        public int UserId { get; set; }
        public int TicketId { get; set; }
        public string Description { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdateddAt { get; set; }

        public UserDto User { get; set; }
        public TicketDto Ticket { get; set; }
    }
}
