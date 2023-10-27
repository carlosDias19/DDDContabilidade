
using DDD.Domain.UserManagementContext;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDD.Domain.ContabilidadeContext
{
    public class Funcionario : User
    {
        [Range(0, 5000, ErrorMessage ="Seu salario nao pode ser maior que 5000 e nem menor que 0")]
        public int Salario { get; set; }
        [Required]
        public string Cargo { get; set; }
        public DateTime DataAdmissao { get; set; }
    }
}
