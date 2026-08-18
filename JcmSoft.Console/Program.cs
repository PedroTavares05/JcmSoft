using JcmSoft.Domain.Entities;
using JcmSoftEFCore.Context;
using System;

using (AppDbContext context = new AppDbContext()) 
{
    context.Database.EnsureDeleted();
    Console.WriteLine("Banco de dados deletado com sucesso!");
    Console.WriteLine("Criando Banco de dados novo");
    context.Database.EnsureCreated();
    Console.WriteLine("O departamento foi criado");
    CriarFuncionario(context);
    //var departamentos = context.Departamentos.ToList();
    //foreach (var item in departamentos)
    //{
    //    Console.WriteLine($"{item.CodigoID}: {item.Nome} | {item.Descricao}");
    //}
    //var Departamento = context.Departamentos.FirstOrDefault(d => d.CodigoID == 3);
    //Console.WriteLine(Departamento != null ? $"O ID do Departamento é {Departamento.CodigoID} e o nome é {Departamento.Nome}":"Departamento não encontrado");
}
Console.ReadKey();

//void CriarDepartamento(AppDbContext context)
//{
    
//    //context.Departamentos.AddRange(departamentos);
//    //context.SaveChanges();
//    //Console.WriteLine("Departamentos criados com sucesso!");
//}
void CriarFuncionario(AppDbContext context)
{
    var funcionario = new Funcionario
    {
        Nome = "João Silva",
        Cargo = "Analista de Sistemas",
        Salario = 5000.00m,
        DepartamentoID = 1
    };
    context.Funcionarios.Add(funcionario);
    context.SaveChanges();
    Console.WriteLine("Funcionário criado com sucesso!");
}