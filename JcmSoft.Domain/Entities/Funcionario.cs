using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using JcmSoft.Domain.Entities;
using System.Data;
namespace JcmSoft.Domain.Entities;

public class Funcionario
{
    public int FuncionarioID { get; set; }
    public string? Nome { get; set; }
    public string? Cargo { get; set; }
    public decimal Salario { get; set; }
    public DateTime DataContratacao { get; set; }
    //FK
    public int DepartamentoID { get; set; }
    //Navegação
    public Departamento? Departamento { get; set; }
}
public class FuncionarioDetalhe
{
    //FK
    public int FuncionarioID { get; set; }
    //Navegação
    public Funcionario? Funcionario { get; set; }
    //PK
    public int FuncionarioDetalheID { get; set; }
    public DateTime DataNascimento { get; set; }
    public string? Endereco { get; set; }
    public string? Telefone { get; set; }
    public string? CPF { get; set; }
    public string? Nacionalidade { get; set; }
    public Genero? Genero { get; set; }
    public Escolariedade? Escolariedade { get; set; }
    public EstadoCivil? EstadoCivil { get; set; }

}