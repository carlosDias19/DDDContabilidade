
using DDD.Domain.UserManagementContext;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDD.Domain.ContabilidadeContext
{
    public class FolhaDePagamento
    {
        public int FolhaDePagamentoId { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        [Range(0, 5000, ErrorMessage = "O Valor da Folha de Pagamento nao pode ser maior que 5.000")]
        [Required]
        public decimal Valor { get; set; }
        public int UserId { get; set; }
    }
}
