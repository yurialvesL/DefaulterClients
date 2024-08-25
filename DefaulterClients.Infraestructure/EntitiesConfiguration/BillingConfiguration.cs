using DefaulterClients.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DefaulterClients.Infraestructure.EntitiesConfiguration;

public class BillingConfiguration : IEntityTypeConfiguration<Billing>
{
    public void Configure(EntityTypeBuilder<Billing> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Description)
             .HasMaxLength(280)
             .IsRequired();

        builder.Property(x => x.Value)
            .HasColumnType("decimal(18,2)");

        builder.Property(x => x.DueDate)
            .HasColumnType("date")
            .IsRequired();

        builder.Property(x => x.Paid)
            .HasColumnType("boolean")
            .IsRequired();

        builder.HasOne(b => b.Client)
            .WithMany(c => c.Billings)  
            .HasForeignKey(b => b.ClientId); 



    }
}
