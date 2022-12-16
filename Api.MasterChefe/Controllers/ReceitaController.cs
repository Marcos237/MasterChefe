using Api.MasterChefe.Aplications.Interfaces;
using Api.MasterChefe.Domain.Entidades;
using Api.MasterChefe.Domain.Interface;
using Microsoft.AspNetCore.Mvc;

namespace Api.MasterChefe.Web.Controllers
{
    [Route("api/Receita")]
    [ApiController]
    public class ReceitaController : Controller
    {
        private readonly IReceitasAplicationsService receitasAplicationsService;
        private readonly IEventoService eventoService;
        public ReceitaController(IReceitasAplicationsService receitasAplicationsService, IEventoService eventoService)
        {
            this.receitasAplicationsService = receitasAplicationsService;
            this.eventoService = eventoService;
        }

        [ProducesResponseType(typeof(Receita), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(List<string>), StatusCodes.Status404NotFound)]
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var dados = await receitasAplicationsService.BuscarTodos();
                if (dados.Count() == 0)
                {
                    return NotFound("Nenhum item encontrado");
                }

                return Ok(dados);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new Exception(ex.Message.ToString()));
            }
        }


        [ProducesResponseType(typeof(Receita), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(List<string>), StatusCodes.Status404NotFound)]
        [Route("{id}")]
        [HttpGet]
        public async Task<IActionResult> Get(int id)
            {
            try
            {
                var dados = await receitasAplicationsService.BuscarPorId(id);
                if (dados == null)
                {
                    return NotFound("Nenhum item encontrado");
                }

                return Ok(dados);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new Exception(ex.Message.ToString()));
            }
        }


        [ProducesResponseType(typeof(Receita), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(List<string>), StatusCodes.Status500InternalServerError)]
        [HttpPost]
        public async Task<IActionResult> Post(Receita receita)
        {
            try
            {
                var dados = await receitasAplicationsService.Salvar(receita);
                if (eventoService.Evento.eventos.Count() > 0)
                {
                    return BadRequest(eventoService.Evento.eventos);
                }

                return Ok(dados);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new Exception(ex.Message.ToString()));
            }
        }

        [ProducesResponseType(typeof(Receita), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(List<string>), StatusCodes.Status500InternalServerError)]
        [HttpPut]
        public async Task<IActionResult> Put(Receita receita)
        {
            try
            {
                var dados = await receitasAplicationsService.Atualizar(receita);
                if (eventoService.Evento.eventos.Count() > 0)
                {
                    return BadRequest(eventoService.Evento.eventos);
                }

                return Ok(dados);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new Exception(ex.Message.ToString()));
            }
        }


        [ProducesResponseType(typeof(Receita), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(List<string>), StatusCodes.Status500InternalServerError)]
        [Route("{id}")]
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var dados = await receitasAplicationsService.Desativar(id);
                if (eventoService.Evento.eventos.Count() > 0)
                {
                    return BadRequest(eventoService.Evento.eventos);
                }

                return Ok("Item Removido");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new Exception(ex.Message.ToString()));
            }
        }
    }
}
