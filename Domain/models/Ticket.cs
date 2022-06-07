using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.models
{
    [Table("Tickets")]
    public class Ticket
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("TicketId")]
        public int TicketId { get; set; }
        [Column("Description")]
        public string Description { get; set; }
        [Column("CaseNumber")]
        [NotMapped]
        public int CaseNumber { get; set; }
        [Column("ReportedBy")]
        [NotMapped]
        public string ReportedBy { get; set; }
        [Column("AssignedTo")]
        public string AssignedTo { get; set; }
        [Column("PriorityId")]
        public int PriorityId { get; set; }
        [Column("CategoryId")]
        public int CategoryId { get; set; }
        [Column("StatusId")]
        public int StatusId { get; set; }
        [Column("CreatedAt")]
        public DateTime CreatedAt { get; set; }
        [Column("UpdatedAt")]
        public DateTime? UpdatedAt { get; set; }
        [NotMapped]
        public User ReportedByUser { get; set; }
        [NotMapped]
        public User AssignedToUser { get; set; }
        public Priority Priority { get; set; }
        public Category Category { get; set; }
        public Status Status { get; set; }
        public ICollection<Comment> Comments { get; set; }
        public ICollection<RecordTicket> RecordTickets { get; set; }
        public ICollection<LogTime> LogTimes { get; set; }
    }
}
