using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.models
{
    [Table("Deparments")]
    public class Deparment
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("DeparmentId")]
        public int DeparmentId { get; set; }
        [Column("Name")]
        public string Name { get; set; }
        [Column("Description")]
        public string? Description { get; set; }
        [Column("CreatedAt")]
        public DateTime CreatedAt { get; set; }
        [Column("UpdatedAt")]
        public DateTime? UpdatedAt { get; set; }

        public ICollection<User> Users { get; set; }
    }
}
