using System.ComponentModel.DataAnnotations;

namespace Domain.models.dto
{
    public class TicketDto
    {
        public int TicketId { get; set; }
        [Required]
        public string Description { get; set; }
        public int CaseNumber { get; set; }
        public string ReportedBy { get; set; }
        public string AssignedTo { get; set; }
        public int PriorityId { get; set; }
        public int CategoryId { get; set; }
        public int StatusId { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public PriorityDto Priority { get; set; }
        public CategoryDto Category { get; set; }
        public StatusDto Status { get; set; }
        public List<CommentDto> Comments { get; set; }
        public List<LogTimeDto> LogTimes { get; set; }
    }
}
