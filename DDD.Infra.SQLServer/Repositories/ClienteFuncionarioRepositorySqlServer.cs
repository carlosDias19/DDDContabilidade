using DDD.Domain.ContabilidadeContext;
using DDD.Infra.SQLServer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDD.Infra.SQLServer.Repositories
{
    public class ClienteFuncionarioRepositorySqlServer : IClienteFuncionarioRepository
    {
        private readonly SqlContext _context;

        public ClienteFuncionarioRepositorySqlServer(SqlContext context)
        {
            _context = context;
        }


        public void DeleteClienteFuncionario(int idClienteFunc)
        {
            try
            {
               var  idCli= _context.ClienteFuncionario.FirstOrDefault(x => x.ClienteFuncionarioId == idClienteFunc);
                if ( idClienteFunc != null ) 
                {
                    _context.ClienteFuncionario.Remove(idCli);
                    _context.SaveChanges();
                }

          

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public ClienteFuncionario GetClienteFuncionarioById(int id)
        {
            return _context.ClienteFuncionario.Find(id);
        }

        public List<ClienteFuncionario> GetClienteFuncionario()
        {
            return _context.ClienteFuncionario.ToList();
        }

        public ClienteFuncionario InsertClienteFuncionario(int idCliente, int idFuncionario)
        {
            var cliente = _context.Cliente.First(i => i.ClienteId == idCliente);
            var funcionario = _context.Funcionario.First(i => i.UserId == idFuncionario);

            var ClienteFuncionario = new ClienteFuncionario
            {
                ClienteId = cliente.ClienteId,
                FuncionarioId = funcionario.UserId,
                DataInicioRelacionamento = new DateTime(),
                DataFinalRelacionamento = new DateTime()
            };

            try
            {

                _context.Add(ClienteFuncionario);
                _context.SaveChanges();

            }
            catch (Exception ex)
            {
                var msg = ex.InnerException;
                throw;
            }

            return ClienteFuncionario;
        }

        public void UpdateClienteFuncionario(ClienteFuncionario clienteFuncionario)
        {
               
        }
    }
}
