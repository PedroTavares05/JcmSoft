using JcmSoft.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JcmSoftEFCore.Context;

public class AppDbContext : DbContext
{
    public DbSet<Departamento> Departamentos { get; set; }
    public DbSet<Funcionario> Funcionarios { get; set; }
    public DbSet<FuncionarioDetalhe> FuncionariosDetalhes { get; set; }
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
                    entity.HasData
                            (
                                new Funcionario { Cargo = "Analista de Sistemas", DataContratacao = new DateTime(2016, 6, 4), DepartamentoID = 4, FuncionarioID = 1, Nome = "João Silva", Salario = 5000.00m },
                                new Funcionario { Cargo = "Analista de Marketing", DataContratacao = new DateTime(2019, 6, 4), DepartamentoID = 3, FuncionarioID = 2, Nome = "Maria Souza", Salario = 4000.00m },
                                new Funcionario { Cargo = "Analista Financeiro", DataContratacao = new DateTime(2026, 6, 4), DepartamentoID = 2, FuncionarioID = 3, Nome = "Carlos Oliveira", Salario = 4500.00m },
                                new Funcionario { Cargo = "Analista de Recursos Humanos", DataContratacao = new DateTime(2026, 6, 4), DepartamentoID = 1, FuncionarioID = 4, Nome = "Ana Santos", Salario = 4200.00m },
                                new Funcionario { Cargo = "Analista de Vendas", DataContratacao = new DateTime(2026, 6, 4), DepartamentoID = 5, FuncionarioID = 5, Nome = "Pedro Lima", Salario = 4800.00m },
                                new Funcionario { Cargo = "Analista de Sistemas", DataContratacao = new DateTime(2026, 6, 4), DepartamentoID = 4, FuncionarioID = 6, Nome = "João Silva", Salario = 5000.00m },
                                new Funcionario { Cargo = "Analista de Marketing", DataContratacao = new DateTime(2026, 6, 4), DepartamentoID = 3, FuncionarioID = 7, Nome = "Maria Souza", Salario = 4000.00m },
                                new Funcionario { Cargo = "Analista Financeiro", DataContratacao = new DateTime(2020, 6, 4), DepartamentoID = 2, FuncionarioID = 8, Nome = "Carlos Oliveira", Salario = 4500.00m },
                                new Funcionario { Cargo = "Analista de Recursos Humanos", DataContratacao = new DateTime(2023, 6, 4), DepartamentoID = 1, FuncionarioID = 9, Nome = "Ana Santos", Salario = 4200.00m },
                                new Funcionario { Cargo = "Analista de Vendas", DataContratacao = new DateTime(2024, 8, 4), DepartamentoID = 5, FuncionarioID = 10, Nome = "Pedro Lima", Salario = 4800.00m }
                                );
                }
            );
        modelBuilder.Entity<FuncionarioDetalhe>().HasKey(fd => fd.FuncionarioDetalheID);
        modelBuilder.Entity<FuncionarioDetalhe>(entity =>
                    {
                        entity.Property(fd => fd.FuncionarioDetalheID).ValueGeneratedOnAdd();
                        entity.Property(fd => fd.Endereco).IsRequired().HasMaxLength(200);
                        entity.Property(fd => fd.Telefone).IsRequired().HasMaxLength(20);
                        entity.Property(fd => fd.DataNascimento).IsRequired();
                        entity.Property(fd => fd.Endereco).HasColumnName("Endereco_Funcionario");
                        entity.Property(fd => fd.Telefone).HasColumnName("Telefone_Funcionario");
                        entity.Property(fd => fd.DataNascimento).HasColumnName("Data_de_Nascimento");
                        entity.Property(fd => fd.CPF).IsRequired().HasMaxLength(14);
                        entity.HasData

                                (
                                    new FuncionarioDetalhe { FuncionarioDetalheID = 1, Endereco = "Rua A, 123", Telefone = "(11) 1234-5678", DataNascimento = new DateTime(1990, 1, 1), FuncionarioID = 1, CPF = "123.456.789-00", Nacionalidade = "Brasileiro", Genero = Genero.Masculino, Escolariedade = Escolariedade.Doutorado, EstadoCivil = EstadoCivil.Solteiro },
                                    new FuncionarioDetalhe { FuncionarioDetalheID = 2, Endereco = "Rua B, 456", Telefone = "(11) 9876-5432", DataNascimento = new DateTime(1992, 2, 2), FuncionarioID = 2, CPF = "987.654.321-00", Nacionalidade = "Brasileiro", Genero = Genero.Feminino, Escolariedade = Escolariedade.EnsinoSuperior, EstadoCivil = EstadoCivil.Casado },
                                    new FuncionarioDetalhe { FuncionarioDetalheID = 3, Endereco = "Rua C, 789", Telefone = "(11) 5555-5555", DataNascimento = new DateTime(1985, 3, 3), FuncionarioID = 3, CPF = "111.222.333-44", Nacionalidade = "Brasileiro", Genero = Genero.Masculino, Escolariedade = Escolariedade.Mestrado, EstadoCivil = EstadoCivil.Divorciado },
                                    new FuncionarioDetalhe { FuncionarioDetalheID = 4, Endereco = "Rua D, 321", Telefone = "(11) 4444-4444", DataNascimento = new DateTime(1995, 4, 4), FuncionarioID = 4, CPF = "555.666.777-88", Nacionalidade = "Brasileiro", Genero = Genero.Feminino, Escolariedade = Escolariedade.Mestrado, EstadoCivil = EstadoCivil.Solteiro }
                                );
                    });


    }
}
