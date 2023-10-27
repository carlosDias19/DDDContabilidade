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
    public class ClienteRepositorySqlServer : IClienteRepository
    {

        private readonly SqlContext _context;

        public ClienteRepositorySqlServer(SqlContext context)
        {
            _context = context;
        }

        public void DeleteCliente(Cliente cliente)
        {
            try
            {
                _context.Set<Cliente>().Remove(cliente);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public Cliente GetClienteById(int id)
        {
            return _context.Cliente.Find(id);
        }

        public List<Cliente> GetCliente()
        {
            //return  _context.Alunos.Include(x => x.Disciplinas).ToList();
            return _context.Cliente.ToList();

        }

        public void InsertCliente(Cliente cliente)
        {
            try
            {
                _context.Cliente.Add(cliente);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                //log exception

            }
        }


        public void UpdateCliente(Cliente cliente)
        {
            try
            {
                _context.Entry(cliente).State = EntityState.Modified;
                _context.SaveChanges();

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

    }
}
