using JcmSoft.Domain.Entities;
using JcmSoftEFCore.Context;
using System;

using (AppDbContext context = new AppDbContext()) 
{
    context.Database.EnsureDeleted();
    Console.WriteLine("Banco de dados deletado com sucesso!");
    Console.WriteLine("Criando Banco de dados novo");
    context.Database.EnsureCreated();
    CriarDepartamento(context);
    Console.WriteLine("O departamento foi criado");
}
Console.ReadKey();

void CriarDepartamento(AppDbContext context)
{
    Departamento departamento = new Departamento();
    departamento.Nome = "Departamento de TI";
    departamento.Descricao = "Departamento de Tecnologia da Informação e projetos";
    context.Departamentos.Add(departamento);
    context.SaveChanges();
}