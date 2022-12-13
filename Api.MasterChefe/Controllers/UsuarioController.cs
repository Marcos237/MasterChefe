using Api.MasterChefe.Aplications.Interfaces;
using Api.MasterChefe.Domain.Entidades;
using Microsoft.AspNetCore.Mvc;

namespace Api.MasterChefe.Web.Controllers
{
    [Route("Controller")]
    [ApiController]
    public class UsuarioController : Controller
    {
        private readonly IUsuarioAplicationService usuarioAplicationService;
        public UsuarioController(IUsuarioAplicationService usuarioAplicationService)
        {
            this.usuarioAplicationService = usuarioAplicationService;
        }

        [ProducesResponseType(typeof(Usuario), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet]
        public async Task<IActionResult> Get(string nome, string senha)
        {
            try
            {
                var dados = await usuarioAplicationService.BuscarUsuario(nome, senha);
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
    }
}
