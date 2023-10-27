using DDD.Domain.ContabilidadeContext;
using DDD.Infra.SQLServer.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DDD.Application.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        readonly IClienteRepository _clienteRepository;

        public ClienteController(IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }

        // GET: api/<AlunosController>
        [HttpGet]
        public ActionResult<List<Cliente>> Get()
        {
            return Ok(_clienteRepository.GetCliente());
        }

        [HttpGet("{id}")]
        public ActionResult<Cliente> GetById(int id)
        {
            return Ok(_clienteRepository.GetClienteById(id));
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<Cliente> CreateCliente(Cliente cliente)
        {
            if (cliente == null)
                return BadRequest("Adicionei algum cliente");
            if (cliente.Nome == "") 
                return BadRequest("Adicione algum nome ao cliente");
            _clienteRepository.InsertCliente(cliente);
            return CreatedAtAction(nameof(GetById), new { id = cliente.ClienteId }, cliente);
        }

        [HttpPut]
        public ActionResult Put([FromBody] Cliente cliente)
        {
            try
            {
                if (cliente == null)
                    return NotFound("Cliente nao foi encontrado");
                if (cliente.Nome == "")
                    return BadRequest("Adicione algum nome ao cliente");

                _clienteRepository.UpdateCliente(cliente);
                return Ok("Cliente Atualizado com sucesso!");
            }
            catch (Exception)
            {

                throw;
            }
        }

        // DELETE api/values/5
        [HttpDelete()]
        public ActionResult Delete([FromBody] Cliente cliente)
        {
            try
            {
                if (cliente == null)
                    return NotFound();

                _clienteRepository.DeleteCliente(cliente);
                return Ok("Cliente Removido com sucesso!");
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

    }
}
