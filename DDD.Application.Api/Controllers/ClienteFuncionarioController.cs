using DDD.Domain.ContabilidadeContext;
using DDD.Infra.SQLServer.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static System.Net.WebRequestMethods;

namespace DDD.Application.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteFuncionarioController : ControllerBase
    {
        readonly IClienteFuncionarioRepository _clienteFuncionarioRepository;

        public ClienteFuncionarioController(IClienteFuncionarioRepository clienteFuncionarioRepository)
        {
            _clienteFuncionarioRepository = clienteFuncionarioRepository; 
        }

        [HttpGet]
        public ActionResult<List<ClienteFuncionario>> Get()
        {
            return Ok(_clienteFuncionarioRepository.GetClienteFuncionario());
        }

        [HttpGet("{id}")]
        public ActionResult<ClienteFuncionario> GetById(int id)
        {
            return Ok(_clienteFuncionarioRepository.GetClienteFuncionarioById(id));
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<ClienteFuncionario> CreateClienteFuncionario(int ClienteId, int FuncionarioId)
        {
            ClienteFuncionario ClienteFuncionarioIdSaved = _clienteFuncionarioRepository.InsertClienteFuncionario(ClienteId, FuncionarioId);
            return CreatedAtAction(nameof(GetById), new { id = ClienteFuncionarioIdSaved.ClienteFuncionarioId }, ClienteFuncionarioIdSaved);
        }

        //[HttpPut]
        //public ActionResult Put([FromBody] Aluno aluno)
        //{
        //    try
        //    {
        //        if (aluno == null)
        //            return NotFound();

        //        _alunoRepository.UpdateAluno(aluno);
        //        return Ok("Cliente Atualizado com sucesso!");
        //    }
        //    catch (Exception)
        //    {

        //        throw;
        //    }
        //}

        /// delete api/values/5
        [HttpDelete()]
        public ActionResult<ClienteFuncionario> Delete(int clientefunId)
        {
            try
            {
                if (clientefunId == null)
                    return NotFound("Cliente Usuario Nao Encontrado");


                _clienteFuncionarioRepository.DeleteClienteFuncionario(clientefunId);
                return Ok("Cliente usuario removido com sucesso!");
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

    }
}
