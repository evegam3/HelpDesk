using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.models
{
    [Table("tickets")]
    public class Ticket
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Column("ticket_id")]
        public int TicketId { get; set; }
        [Column("description")]
        public string Description { get; set; }
        [Column("case_number")]
        public int CaseNumber { get; set; }
        [Column("reported_by")]
        public int ReportedBy { get; set; }
        [Column("assigned_to")]
        public int AssignedTo { get; set; }
        [Column("priority_id")]
        public int PriorityId { get; set; }
        [Column("category_id")]
        public int CategoryId { get; set; }
        [Column("status_id")]
        public int StatusId { get; set; }
        [Column("created_at")]
        public DateTime CreatedAt { get; set; }
        [Column("updated_at")]
        public DateTime? UpdateddAt { get; set; }
        public User ReportedByUser { get; set; }
        public User AssignedToUser { get; set; }
        public Priority Priority { get; set; }
        public Category Category { get; set; }
        public Status Status { get; set; }
        public ICollection<Comment> Comments { get; set; }
        public ICollection<RecordTicket> RecordTickets { get; set; }
        public ICollection<LogTime> LogTimes { get; set; }
    }
}
