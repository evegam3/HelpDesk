namespace Domain.models.dto
{
    public class RolDto
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string NormalizedName { get; set; }
        public string ConcurrencyStamp { get; set; }

        public List<UserRoleDto> UserRoles { get; set; }
    }
}
