using CadastroNumeros.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace CadastroNumeros.Infra.Data;

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
            entity.Property(e => e.DataCriacao).HasColumnName("DataCriacao").HasColumnType("DATETIME").IsRequired();
            entity.Property(e => e.Nome).HasColumnType("VARCHAR(100)").IsRequired();
            entity.Property(e => e.Idade).HasColumnType("INT").IsRequired();
            entity.Property(e => e.NumeroTel).HasColumnType("INT").IsRequired();
            entity.Property(e => e.Endereco).HasColumnType("VARCHAR(256)").IsRequired();

            entity.HasOne(e => e.DDD).WithMany(d => d.Contatos).HasForeignKey(e => e.DDDId).IsRequired();
        });
        modelBuilder.Entity<DDD>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e._DDD).HasColumnType("VARCHAR(3)").IsRequired();
        });
    }
}
