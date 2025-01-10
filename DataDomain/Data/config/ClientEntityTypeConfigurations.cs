using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using DataDomain.Data.entity;

namespace DataDomain.Data.config
{
    public class ClientEntityTypeConfigurations : IEntityTypeConfiguration<Client>
    {
        public void Configure(EntityTypeBuilder<Client> builder)
        {
            builder
                .HasOne(cli => cli.Code)
                .WithOne(code => code.User)
                .HasForeignKey<Code>(code => code.ClientId);
            builder
                .HasIndex(cli => cli.Email)
                .IsUnique();
            builder
                .HasIndex(cli => cli.UserName)
                .IsUnique();
            builder
                .Property(cli => cli.IsActivated)
                .HasDefaultValue(false);
        }

 
    }
}
