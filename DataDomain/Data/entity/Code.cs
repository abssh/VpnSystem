namespace DataDomain.Data.entity
{
    public class Code
    {
        public int Id { get; set; }
        public required string Value { get; set; }
        public DateTime UpdatedAt { get; set; }
        public DateTime ValidUntil { get; set; }
        public Guid ClientId { get; set; }

        public required Client User { get; set; }
    }
}
