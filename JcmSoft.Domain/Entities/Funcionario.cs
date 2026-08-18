using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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
