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
    public DbSet <Funcionario> Funcionarios { get; set; }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
      
        string conexao = AppConfig.GetConnectionString();
        ServerVersion versaoDoServidor = ServerVersion.AutoDetect(conexao);

        optionsBuilder.UseMySql(conexao, versaoDoServidor);
    }
    override protected void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Departamento>().HasKey(d => d.DepartamentoID);
        modelBuilder.Entity<Departamento>(entity =>
        {
            entity.Property(d => d.DepartamentoID).ValueGeneratedOnAdd(); 
            entity.Property(d => d.Data).HasDefaultValueSql("CURRENT_TIMESTAMP(6)");
            entity.Property(d => d.Nome).IsRequired().HasMaxLength(100);
            entity.Property(d => d.Descricao).IsRequired().HasMaxLength(500);
            entity.Property(d => d.Descricao).HasColumnName("Descricao_Departamento");
            entity.Property(d => d.Nome).HasColumnName("Nome_Departamento");
            entity.HasData(
                new Departamento { DepartamentoID = 1, Nome = "Recursos Humanos", Descricao = "Departamento responsável pela gestão de pessoas e recursos humanos da empresa." },
                new Departamento { DepartamentoID = 2, Nome = "Financeiro", Descricao = "Departamento responsável pela gestão financeira da empresa, incluindo contabilidade, orçamento e análise financeira." },
                new Departamento { DepartamentoID = 3, Nome = "Marketing", Descricao = "Departamento responsável pela promoção e divulgação dos produtos ou serviços da empresa, bem como pela pesquisa de mercado e estratégias de marketing." },
                new Departamento { DepartamentoID = 4, Nome = "Tecnologia da Informação", Descricao = "Departamento responsável pela gestão da infraestrutura tecnológica da empresa, incluindo hardware, software, redes e segurança da informação." },
                new Departamento { DepartamentoID = 5, Nome = "Vendas", Descricao = "Departamento responsável pela comercialização dos produtos ou serviços da empresa, incluindo prospecção de clientes, negociação e fechamento de vendas." }
            );
        });
        modelBuilder.Entity<Funcionario>
            (entity => 
                {
                    entity.Property(f => f.FuncionarioID).ValueGeneratedOnAdd();
                    entity.HasKey(f => f.FuncionarioID);
                    entity.Property(f => f.DataContratacao).HasDefaultValueSql("CURRENT_TIMESTAMP(6)");
                    entity.Property(f => f.Nome).IsRequired().HasMaxLength(100);
                    entity.Property(f => f.Cargo).IsRequired().HasMaxLength(50);
                    entity.Property(f => f.Salario).IsRequired().HasColumnType("decimal(18,2)");
                    entity.Property(f => f.Cargo).HasColumnName("Cargo_Funcionario");
                    entity.Property(f => f.DataContratacao).HasColumnName("Data_de_Contratacao");
                    entity.Property(f => f.Nome).HasColumnName("Nome_Funcionario");
                    entity.Property(f => f.Salario).HasColumnName("Salario_Funcionario");
                    entity.Property(f => f.Salario).HasColumnType("decimal(12,2)");
                }
            );
    }
}
