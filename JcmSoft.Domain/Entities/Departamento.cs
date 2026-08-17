using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JcmSoft.Domain.Entities;


public class Departamento
{
    [Key]
    [Column("DepartamentoID")]
    public int CodigoID { get; set; }
    [Column("Nome_Departamento")]
    [MaxLength(100)]
    [Required]
    public string Nome { get; set; } = string.Empty;
    [MaxLength(250)]
    [Column("Descricao_Departamento")]
    [Required]
    public string Descricao { get; set; } = string.Empty;
    [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
    public DateTime Data {  get; set; }

}
