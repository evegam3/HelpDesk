using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Domain.models
{
    [Table("Priorities")]
    public class Priority
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("PriorityId")]
        public int PriorityId { get; set; }
        [Column("Name")]
        public string Name { get; set; }
        [Column("Description")]
        public string? Description { get; set; }
        [Column("CreatedAt")]
        public DateTime CreatedAt { get; set; }
        [Column("UpdatedAt")]
        public DateTime? UpdatedAt { get; set; }
        public ICollection<Ticket> Tickets { get; set; }
    }
}
