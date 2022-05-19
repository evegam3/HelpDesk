using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.models
{
    public class Rol
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Column("rol_id")]
        public int RolId { get; set; }
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        [Column("name")]
        public string Name { get; set; }
        [Column("description")]
        public string Description { get; set; }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        [Column("created_at")]
        public DateTime CreatedAt { get; set; }
        [Column("updated_at")]
        public DateTime? UpdateddAt { get; set; }
        public ICollection<RolUser> RolUsers { get; set; }
    }
}
