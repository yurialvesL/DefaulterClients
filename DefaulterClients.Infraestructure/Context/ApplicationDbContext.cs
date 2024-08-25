using DefaulterClients.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace DefaulterClients.Infraestructure.Context;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options)
    {
        
    }

    public DbSet<User> Users { get; set; }
    public DbSet<Client> Clients { get; set; }  
    public DbSet<Billing> Billings { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
    }

}
