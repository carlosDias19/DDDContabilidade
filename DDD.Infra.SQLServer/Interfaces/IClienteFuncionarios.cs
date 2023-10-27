using DDD.Domain.ContabilidadeContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDD.Infra.SQLServer.Interfaces
{
    public interface IClienteFuncionarioRepository
    {
        public List<ClienteFuncionario> GetClienteFuncionario();
        public ClienteFuncionario GetClienteFuncionarioById(int id);
        public ClienteFuncionario InsertClienteFuncionario(int idCliente, int idFuncionario);
        public void UpdateClienteFuncionario(ClienteFuncionario clienteFuncionario);
        public void DeleteClienteFuncionario(int clienteFunId);
        //asdasdas
    }
}
