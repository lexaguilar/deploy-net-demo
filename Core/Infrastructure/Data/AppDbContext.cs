using Microsoft.EntityFrameworkCore;
using TaskManagerAPI.Core.Domain.Entities;

namespace TaskManagerAPI.Core.Infrastructure.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }
    
    public DbSet<Tarea> Tareas { get; set; }
    public DbSet<Cliente> Clientes { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Tarea>()
            .HasOne(t => t.Cliente)
            .WithMany(c => c.Tareas)
            .HasForeignKey(t => t.ClienteId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}