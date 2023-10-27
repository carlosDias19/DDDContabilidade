using DDD.Domain.ContabilidadeContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDD.Infra.SQLServer.Interfaces
{
    public interface IFolhaDePagamentoRepository
    {
        public List<FolhaDePagamento> GetFolhaDePagamento();
        public FolhaDePagamento GetFolhaDePagamentoById(int id);
        public void InsertFolhaDePagamento(FolhaDePagamento folhaDePagamento);
        public void UpdateFolhaDePagamento(FolhaDePagamento folhaDePagamento);
        public void DeleteFolhaDePagamento(FolhaDePagamento folhaDePagamento);
    }
}
