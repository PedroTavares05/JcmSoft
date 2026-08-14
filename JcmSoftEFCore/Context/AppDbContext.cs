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
}
