using Microsoft.EntityFrameworkCore;
using Teste_Codificar.Models;

namespace Teste_Codificar.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public DbSet<Chamado> Chamados { get; set; }

    public DbSet<Responsavel> Responsaveis { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Responsavel>().HasData(
            new Responsavel
            {
                Id = 1,
                Nome = "João Silva"
            },
            new Responsavel
            {
                Id = 2,
                Nome = "Maria Santos"
            },
            new Responsavel
            {
                Id = 3,
                Nome = "Carlos Oliveira"
            }
        );
    }
}