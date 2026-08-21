using JcmSoft.Domain.Entities;
using JcmSoftEFCore.Context;
using JcmSoft.Domain.Entities.Enums;
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
    var grupos = context.Funcionarios.GroupBy(f => f.Cargo).ToList();
    foreach (var item in grupos)
    {
        Console.WriteLine(item.Key);
        foreach (var item1 in item)
        {
            Console.WriteLine($"{item1.Nome}\t {item1.Salario}");
        }
    }
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
    var cliente = new Cliente
    {
        Nome = "Tech Corp Internacional",
        Email = "contato@techcorp.com",
        Projetos = new List<Projeto> // Usando a propriedade de navegação
    {
        new Projeto
        {
            Nome = "Migração para Nuvem",
            Orcamento = 150000.00M,
            DataInicio = DateTime.Now,
            ClienteID = 1,
            Descricao= "Projeto voltado para migração em nuvem",
            Estado= EstadoProjeto.EmAndamento,

        }
    }
    };

    // 2. Criando o Departamento, o Funcionário e o Detalhe de uma só vez
    var departamento = new Departamento
    {
        Nome = "Engenharia de Software",
        Descricao = "Setor de desenvolvimento e arquitetura",
        Funcionarios = new List<Funcionario> // Usando a propriedade de navegação
    {
        new Funcionario
        {
            Nome = "Marcos Almeida",
            Cargo = "Desenvolvedor Sênior",
            Salario = 8500.50M,
            DataContratacao = DateTime.Now,
            
            // Aqui está a sua relação 1 para 1 em ação
            FuncionarioDetalhe = new FuncionarioDetalhe
            {
                CPF = "123.456.789-00",
                Telefone = "27999999999",
                DataNascimento = new DateTime(1995, 8, 15),
                // Supondo que você ajustou seus Enums conforme recomendado
                Escolariedade = Escolariedade.EnsinoSuperior,
                EstadoCivil = EstadoCivil.Solteiro,
                Endereco= "Rua Padre Guizan 52 Vitoria Caratoira",
                Genero=Genero.Masculino,
                Nacionalidade= "Brasileira"
            }
        }
    }
    };

    // 3. Adicionando as entidades "Raiz" ao contexto
    context.Clientes.Add(cliente);
    context.Departamentos.Add(departamento);

    // 4. O disparo final
    context.SaveChanges();

    Console.WriteLine("Dados inseridos com sucesso! Verifique o MySQL.");
}
