using System.ComponentModel.DataAnnotations.Schema;

namespace DataDomain.Data.entity
{
    public class Code
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public required string Value { get; set; }
        public DateTime UpdatedAt { get; set; }
        public DateTime ValidUntil { get; set; }
        public Guid ClientId { get; set; }

        public Client User { get; set; }
    }
}
