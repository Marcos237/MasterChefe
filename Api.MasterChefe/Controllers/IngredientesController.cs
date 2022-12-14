using Api.MasterChefe.Aplications.Interfaces;
using Api.MasterChefe.Domain.Entidades;
using Api.MasterChefe.Domain.Interface;
using Microsoft.AspNetCore.Mvc;

namespace Api.MasterChefe.Web.Controllers
{
    [Route("api/Ingrediente")]
    [ApiController]
    public class IngredientesController : Controller
    {
        private readonly IIngredientesAplicationsService ingredientesAplicationsService;
        private readonly IEventoService eventoService;
        public IngredientesController(IIngredientesAplicationsService ingredientesAplicationsService, IEventoService eventoService)
        {
            this.ingredientesAplicationsService = ingredientesAplicationsService;
            this.eventoService = eventoService;
        }

        [ProducesResponseType(typeof(Ingrediente), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(List<string>), StatusCodes.Status404NotFound)]
        [HttpGet]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var dados = await ingredientesAplicationsService.BuscarPorId(id);
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


        [ProducesResponseType(typeof(Ingrediente), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(List<string>), StatusCodes.Status500InternalServerError)]
        [HttpPut]
        public async Task<IActionResult> Put(Ingrediente receita)
        {
            try
            {
                var dados = await ingredientesAplicationsService.Atualizar(receita);
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


        [ProducesResponseType(typeof(Ingrediente), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(List<string>), StatusCodes.Status500InternalServerError)]
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var dados = await ingredientesAplicationsService.Deletar(id);
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
    }
}
