using CadastroNumeros.Models;
using Microsoft.EntityFrameworkCore;

namespace CadastroNumeros.Data;

public class AppDbContext : DbContext
{

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<Contato> Contatos { get; set; }

    public DbSet<DDD> DDDs { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Contato>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.HasOne(e => e.DDD).WithMany(d => d.Contatos).HasForeignKey(e => e.DDDId);
        });
    }
}
