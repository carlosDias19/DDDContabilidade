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
    public class FuncionarioRepositorySqlServer : IFuncionarioRepository
    {

        private readonly SqlContext _context;

        public FuncionarioRepositorySqlServer(SqlContext context)
        {
            _context = context;
        }

        public void DeleteFuncionario(Funcionario funcionario)
        {
            try
            {
                _context.Set<Funcionario>().Remove(funcionario);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public Funcionario GetFuncionarioById(int id)
        {
            return _context.Funcionario.Find(id);
        }

        public List<Funcionario> GetFuncionario()
        {
            //return  _context.Alunos.Include(x => x.Disciplinas).ToList();
            return _context.Funcionario.ToList();

        }

        public void InsertFuncionario(Funcionario funcionario)
        {
            try
            {
                _context.Funcionario.Add(funcionario);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;

            }
        }


        public void UpdateFuncionario(Funcionario funcionario)
        {
            try
            {
                _context.Entry(funcionario).State = EntityState.Modified;
                _context.SaveChanges();

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

    }
}
