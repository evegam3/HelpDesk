namespace Domain.models.dto
{
    public class TicketDto
    {
        public int TicketId { get; set; }
        public string Description { get; set; }
        public int CaseNumber { get; set; }
        public int ReportedBy { get; set; }
        public int AssignedTo { get; set; }
        public int PriorityId { get; set; }
        public int CategoryId { get; set; }
        public int StatusId { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdateddAt { get; set; }
        public UserDto ReportedByUser { get; set; }
        public UserDto AssignedToUser { get; set; }
        public PriorityDto Priority { get; set; }
        public CategoryDto Category { get; set; }
        public StatusDto Status { get; set; }
        public List<CommentDto> Comments { get; set; }
        public List<LogTimeDto> LogTimes { get; set; }
    }
}
