using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.models
{
    [Table("rols_users")]
    public class RolUser
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Column("rol_user_id")]
        public int RolUserId { get; set; }
        [Column("rol_id")]
        public int RolId { get; set; }
        [Column("user_id")]
        public int UserId { get; set; }
        [Column("created_at")]
        public DateTime CreatedAt { get; set; }
        [Column("updated_at")]
        public DateTime? UpdateddAt { get; set; }
        public User User { get; set; }
        public Rol Rol { get; set; }
    }
}
