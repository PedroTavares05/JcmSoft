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
    List<Departamento> departamentos = new List<Departamento>
    {
        new Departamento { Nome = "Recursos Humanos", Descricao = "Departamento responsável pela gestão de pessoas e recursos humanos da empresa." },
        new Departamento { Nome = "Financeiro", Descricao = "Departamento responsável pela gestão financeira da empresa, incluindo contabilidade, orçamento e análise financeira." },
        new Departamento { Nome = "Marketing", Descricao = "Departamento responsável pela promoção e divulgação dos produtos ou serviços da empresa, bem como pela pesquisa de mercado e estratégias de marketing." },
        new Departamento { Nome = "Tecnologia da Informação", Descricao = "Departamento responsável pela gestão da infraestrutura tecnológica da empresa, incluindo hardware, software, redes e segurança da informação." },
        new Departamento { Nome = "Vendas", Descricao = "Departamento responsável pela comercialização dos produtos ou serviços da empresa, incluindo prospecção de clientes, negociação e fechamento de vendas." }
    };
    context.Departamentos.AddRange(departamentos);
    context.SaveChanges();
    Console.WriteLine("Departamentos criados com sucesso!");
}