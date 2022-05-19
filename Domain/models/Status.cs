using System.ComponentModel.DataAnnotations.Schema;


namespace Domain.models
{
    public  class Status
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Column("status_id")]
        public int StatusId { get; set; }
        [Column("name")]
        public string Name { get; set; }
        [Column("description")]
        public string Description { get; set; }
        [Column("created_at")]
        public DateTime CreatedAt { get; set; }
        [Column("updated_at")]
        public DateTime? UpdateddAt { get; set; }
        public ICollection<Ticket> Tickets { get; set; }
    }
}
