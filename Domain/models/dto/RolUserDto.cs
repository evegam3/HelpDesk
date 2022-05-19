namespace Domain.models.dto
{
    public class RolUserDto
    {
        public int RolUserId { get; set; }
        public int RolId { get; set; }
        public int UserId { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdateddAt { get; set; }
        public UserDto User { get; set; }
        public RolDto Rol { get; set; }
    }
}
