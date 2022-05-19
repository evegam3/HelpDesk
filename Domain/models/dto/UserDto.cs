namespace Domain.models.dto
{
    public class UserDto
    {
        public int UserId { get; set; }
        public int DeparmentId { get; set; }
        public string Name { get; set; }
        public string Lastname { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdateddAt { get; set; }

        public DeparmentDto Deparment { get; set; }
        public List<RolUserDto> RolUsers { get; set; }
        public List<TicketDto> AssignedTickets { get; set; }
        public List<TicketDto> ReportedTickets { get; set; }
        public List<CommentDto> Comments { get; set; }
        public List<LogTimeDto> LogTimes { get; set; }
    }
}
