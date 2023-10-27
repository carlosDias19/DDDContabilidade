using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDD.Domain.ContabilidadeContext
{
    public class ClienteFuncionario
    {
        public int ClienteFuncionarioId { get; set; }
        public int ClienteId { get; set; }
        public Cliente Cliente { get; set; }
        public int FuncionarioId { get; set; }
        public Funcionario Funcionario { get; set; }
        public DateTime DataInicioRelacionamento { get; set; }
        public DateTime DataFinalRelacionamento { get; set; }

    }
}
