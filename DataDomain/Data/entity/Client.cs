using System.ComponentModel.DataAnnotations.Schema;

namespace DataDomain.Data.entity
{
    public class Client
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public required DateTime CreatedAt { get; set; }
        public required string UserName { get; set; }
        public required string Password { get; set; }
        public required string Email { get; set; }

        public bool IsActivated { get; set; }
        public Code? Code { get; set; } = null;
    }
}
