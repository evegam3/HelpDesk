
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.models
{
    [Table("comments")]
    public class Comment
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Column("comment_id")]
        public int CommentId { get; set; }
        [Column("user_id")]
        public int UserId { get; set; }
        [Column("ticket_id")]
        public int TicketId { get; set; }
        [Column("description")]
        public string Description { get; set; }
        [Column("created_at")]
        public DateTime CreatedAt { get; set; }
        [Column("updated_at")]
        public DateTime? UpdateddAt { get; set; }

        public User User { get; set; }
        public Ticket Ticket { get; set; }
    }
}
