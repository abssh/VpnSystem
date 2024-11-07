namespace DataDomain.Data.entity
{
    public class Client
    {
        public required Guid Id { get; set; } = Guid.Empty;
        public DateTime CreatedAt { get; set; }
        public required string UserName { get; set; }
        public required string Password { get; set; }
        public required string Email { get; set; }
        public Code? Code { get; set; } = null;
    }
}
