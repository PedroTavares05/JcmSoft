using JcmSoft.Domain.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JcmSoft.Domain.Entities;

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