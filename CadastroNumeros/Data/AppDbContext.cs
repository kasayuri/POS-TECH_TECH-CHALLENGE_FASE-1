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
            entity.Property(e => e.DataCriacao).IsRequired();
            entity.Property(e => e.Nome).IsRequired();
            entity.Property(e => e.Idade).IsRequired();
            entity.Property(e => e.NumeroTel).IsRequired();
            entity.Property(e => e.Endereco).IsRequired();


            entity.HasOne(e => e.DDD).WithMany(d => d.Contatos).HasForeignKey(e => e.DDDId).IsRequired();
        });
        modelBuilder.Entity<DDD>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e._DDD).IsRequired();
        });
    }
}
