using DDD.Domain.ContabilidadeContext;
using DDD.Infra.SQLServer.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DDD.Application.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FuncionarioController : ControllerBase
    {
        readonly IFuncionarioRepository _funcionarioRepository;

        public FuncionarioController(IFuncionarioRepository funcionarioRepository)
        {
            _funcionarioRepository = funcionarioRepository;
        }

        // GET: api/<AlunosController>
        [HttpGet]
        public ActionResult<List<Funcionario>> Get()
        {
            return Ok(_funcionarioRepository.GetFuncionario());
        }

        [HttpGet("{id}")]
        public ActionResult<Funcionario> GetById(int id)
        {
            return Ok(_funcionarioRepository.GetFuncionarioById(id));
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<Funcionario> CreateFuncionario(Funcionario funcionario)
        {
            if (funcionario.Salario < 0)
                return BadRequest("O Salario do funcionario nao pode ser menor que zero");
            _funcionarioRepository.InsertFuncionario(funcionario);
            return CreatedAtAction(nameof(GetById), new { id = funcionario.UserId }, funcionario);
        }

        [HttpPut]
        public ActionResult Put([FromBody] Funcionario funcionario)
        {
            try
            {
                if (funcionario == null)
                    return NotFound();
                if (funcionario.Salario < 0)
                    return BadRequest("O Salario do funcionario nao pode ser menor que zero");

                _funcionarioRepository.UpdateFuncionario(funcionario);
                return Ok("Funcionario Atualizado com sucesso!");
            }
            catch (Exception)
            {

                throw;
            }
        }

        // DELETE api/values/5
        [HttpDelete()]
        public ActionResult Delete([FromBody] Funcionario funcionario)
        {
            try
            {
                if (funcionario == null)
                    return NotFound();

                _funcionarioRepository.DeleteFuncionario(funcionario);
                return Ok("Funcionario Removido com sucesso!");
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

    }
}
