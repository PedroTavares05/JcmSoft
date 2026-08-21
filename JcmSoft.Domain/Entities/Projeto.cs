using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using JcmSoft.Domain.Entities.Enums;

namespace JcmSoft.Domain.Entities;

public class Projeto
{
    //PK
    public int ProjetoID { get; set; }
    //FK
    public int ClienteID { get; set; }
    //Navegação
    public Cliente? Cliente { get; set; }
    //Atributos
    public string Nome { get;set; }
    public decimal Orcamento { get; set; }
    public string Descricao { get; set; }
    public DateTime DataInicio { get; set; }
    public DateTime DataAtualizada { get; set; }
    public DateTime DataFim { get; set; }
    public EstadoProjeto Estado { get; set; }
    //Navegação
    public ICollection<FuncionariosProjetos> FuncionariosProjetos { get; set; } = new List<FuncionariosProjetos>();

}
