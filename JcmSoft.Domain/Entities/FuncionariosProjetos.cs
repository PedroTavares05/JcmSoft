using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JcmSoft.Domain.Entities
{
    public class FuncionariosProjetos
    {
        public int FuncionarioID { get; set; }
        public Funcionario Funcionario { get; set; } = new Funcionario();
        public int ProjetoID { get; set; }
        public Projeto Projeto { get; set; } = new Projeto();
    }
}
