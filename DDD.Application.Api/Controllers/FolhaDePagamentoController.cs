using DDD.Domain.ContabilidadeContext;
using DDD.Infra.SQLServer.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DDD.Application.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FolhaDePagamentoController : ControllerBase
    {
        readonly IFolhaDePagamentoRepository _folhaDePagamentoRepository;

        public FolhaDePagamentoController(IFolhaDePagamentoRepository folhaDePagamentoRepository)
        {
            _folhaDePagamentoRepository = folhaDePagamentoRepository;
        }

        // GET: api/<AlunosController>
        [HttpGet]
        public ActionResult<List<FolhaDePagamento>> Get()
        {
            return Ok(_folhaDePagamentoRepository.GetFolhaDePagamento());
        }

        [HttpGet("{id}")]
        public ActionResult<Funcionario> GetById(int id)
        {
            return Ok(_folhaDePagamentoRepository.GetFolhaDePagamentoById(id));
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<FolhaDePagamento> CreateFolhaDePagamento(FolhaDePagamento folhaDePagamento)
        {
            _folhaDePagamentoRepository.InsertFolhaDePagamento(folhaDePagamento);
            return CreatedAtAction(nameof(GetById), new { id = folhaDePagamento.FolhaDePagamentoId }, folhaDePagamento);
        }

        [HttpPut]
        public ActionResult Put([FromBody] FolhaDePagamento folhaDePagamento)
        {
            try
            {
                if (folhaDePagamento == null)
                    return NotFound();

                _folhaDePagamentoRepository.UpdateFolhaDePagamento(folhaDePagamento);
                return Ok("Folha Atualizada com sucesso!");
            }
            catch (Exception)
            {

                throw;
            }
        }

        // DELETE api/values/5
        [HttpDelete()]
        public ActionResult Delete([FromBody] FolhaDePagamento folhaDePagamento)
        {
            try
            {
                if (folhaDePagamento == null)
                    return NotFound();

                _folhaDePagamentoRepository.DeleteFolhaDePagamento(folhaDePagamento);
                return Ok("Folha Removida com sucesso!");
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

    }
}
