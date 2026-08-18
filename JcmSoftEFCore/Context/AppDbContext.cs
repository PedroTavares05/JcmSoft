using JcmSoft.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JcmSoftEFCore.Context;

public class AppDbContext : DbContext
{
    public DbSet <Departamento> Departamentos { get; set; }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
      
        string conexao = AppConfig.GetConnectionString();
        ServerVersion versaoDoServidor = ServerVersion.AutoDetect(conexao);

        optionsBuilder.UseMySql(conexao, versaoDoServidor);
    }
    override protected void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Departamento>().HasKey(d=>d.CodigoID);
        modelBuilder.Entity<Departamento>
            (entity =>
                {
                    entity.Property(d => d.Data).HasDefaultValueSql("CURRENT_TIMESTAMP(6)");
                    entity.Property(d => d.Nome).IsRequired().HasMaxLength(100);
                    entity.Property(d => d.Descricao).IsRequired().HasMaxLength(500);
                    entity.Property(d => d.Descricao).HasColumnName("Descricao_Departamento");
                    entity.Property(d => d.Nome).HasColumnName("Nome_Departamento");

                }
            );
    }
}
