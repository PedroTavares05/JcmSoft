using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace JcmSoft.Domain.Entities;

public class Departamento
{

    [Key]
    public int DepartemntoId { get; set; }
    public string Nome { get; set; }
    public string Descricao { get; set; }

}
