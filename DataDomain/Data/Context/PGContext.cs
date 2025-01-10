using DataDomain.Data.config;
using DataDomain.Data.entity;
using Microsoft.EntityFrameworkCore;
using System.Configuration;


namespace DataDomain.Data.Context
{

    public class PGContext : DbContext, DSContext
    {

        public PGContext(DbContextOptions<PGContext> options) : base(options) { }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Code> Codes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            new ClientEntityTypeConfigurations().Configure(modelBuilder.Entity<Client>());
        }

    }
}
