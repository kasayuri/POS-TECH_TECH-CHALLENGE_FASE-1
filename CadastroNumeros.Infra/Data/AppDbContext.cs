using CadastroNumeros.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace CadastroNumeros.Infra.Data;

public class AppDbContext : DbContext
{
    // TODO: Verificar erro do migration **ajuste paliativo**
    public AppDbContext()
    {
        
    }
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<Contato> Contatos { get; set; }

    public DbSet<DDD> DDDs { get; set; }

    // TODO: Verificar erro do migration **ajuste paliativo**
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {

        optionsBuilder.UseSqlServer("Server=tcp:postechnet.database.windows.net,1433;Initial Catalog=PosTechNET;Persist Security Info=False;User ID=adminpos;Password=102030@abc;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");

    }

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
            entity.Property(e => e.DDD).HasColumnType("int").IsRequired();

            entity.HasOne(e => e._DDD).WithMany(d => d.Contatos).HasForeignKey(e => e.DDD).IsRequired();
        });
        modelBuilder.Entity<DDD>(entity =>
        {
            entity.HasKey(e => e.Codigo);
            entity.Property(e => e.Codigo).HasColumnType("int").IsRequired();
            entity.Property(e => e.Regiao).HasColumnType("varchar").HasMaxLength(100).IsRequired();
        });
    }
}
