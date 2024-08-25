using DefaulterClients.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DefaulterClients.Infraestructure.EntitiesConfiguration;

public class ClientConfiguration : IEntityTypeConfiguration<Client>
{

    public void Configure(EntityTypeBuilder<Client> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Name)
            .HasMaxLength(50)
            .IsRequired();

        builder.Property(p => p.Document)
            .HasMaxLength(350)
            .IsRequired();

        builder.Property(p => p.Address)
            .HasMaxLength(280)
            .IsRequired();


        builder.HasOne(x => x.User)
            .WithOne()
            .HasForeignKey<Client>(c => c.UserId);

        builder.HasMany(p => p.Billings)
            .WithOne(c => c.Client)
            .HasForeignKey(f => f.ClientId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
