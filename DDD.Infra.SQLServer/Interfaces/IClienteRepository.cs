using DDD.Domain.ContabilidadeContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDD.Infra.SQLServer.Interfaces
{
    public interface IClienteRepository
    {
        public List<Cliente> GetCliente();
        public Cliente GetClienteById(int id);
        public void InsertCliente(Cliente cliente);
        public void UpdateCliente(Cliente cliente);
        public void DeleteCliente(Cliente cliente);
    }
}
