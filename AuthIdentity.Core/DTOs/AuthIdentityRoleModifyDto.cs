namespace AuthIdentity.Core.DTOs
{
    public class AuthIdentityRoleModifyDto
    {
        public required string Id { get; set; }
        public required string Name { get; set; }
        public required string ConcurrencyStamp { get; set; }

    }
}
