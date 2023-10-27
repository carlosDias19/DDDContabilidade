using DDD.Domain.ContabilidadeContext;
using DDD.Infra.SQLServer.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDD.Infra.SQLServer.Repositories
{
    public class FolhaDePagamentoRepositorySqlServer : IFolhaDePagamentoRepository
    {

        private readonly SqlContext _context;

        public FolhaDePagamentoRepositorySqlServer(SqlContext context)
        {
            _context = context;
        }

        public void DeleteFolhaDePagamento(FolhaDePagamento folhaDePagamento)
        {
            try
            {
                _context.Set<FolhaDePagamento>().Remove(folhaDePagamento);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public FolhaDePagamento GetFolhaDePagamentoById(int id)
        {
            return _context.FolhaDePagamento.Find(id);
        }

        public List<FolhaDePagamento> GetFolhaDePagamento()
        {
            //return  _context.Alunos.Include(x => x.Disciplinas).ToList();
            return _context.FolhaDePagamento.ToList();

        }

        public void InsertFolhaDePagamento(FolhaDePagamento folhaDePagamento)
        {
            try
            {
                _context.FolhaDePagamento.Add(folhaDePagamento);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;

            }
        }


        public void UpdateFolhaDePagamento(FolhaDePagamento folhaDePagamento)
        {
            try
            {
                _context.Entry(folhaDePagamento).State = EntityState.Modified;
                _context.SaveChanges();

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

    }
}
