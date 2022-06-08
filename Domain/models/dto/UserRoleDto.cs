namespace Domain.models.dto
{
    public class UserRoleDto
    {
        public string UserId { get; set; }
        public string RoleId { get; set; }

        public  UserDto User { get; set; }
        public  RolDto Role { get; set; }
    }
}
