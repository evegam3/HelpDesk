
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.models
{
    [Table("Comments")]
    public class Comment
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("CommentId")]
        public int CommentId { get; set; }
        [Column("UserId")]
        public string UserId { get; set; }
        [Column("TicketId")]
        public int TicketId { get; set; }
        [Column("Description")]
        public string Description { get; set; }
        [Column("CreatedAt")]
        public DateTime CreatedAt { get; set; }
        [Column("UpdatedAt")]
        public DateTime? UpdatedAt { get; set; }

        public User User { get; set; }
        public Ticket Ticket { get; set; }
    }
}
