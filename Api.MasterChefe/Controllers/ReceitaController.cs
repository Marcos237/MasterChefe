using Api.MasterChefe.Aplications.Interfaces;
using Api.MasterChefe.Domain.Entidades;
using Microsoft.AspNetCore.Mvc;

namespace Api.MasterChefe.Web.Controllers
{
    [Route("Controller")]
    [ApiController]
    public class ReceitaController : Controller
    {
        private readonly IReceitasAplicationsService receitasAplicationsService;
        public ReceitaController(IReceitasAplicationsService receitasAplicationsService)
        {
            this.receitasAplicationsService = receitasAplicationsService;
        }

        [HttpGet]
        public async Task<List<Receita>> Get()
        {
            var dados = await receitasAplicationsService.BuscarTodos();

            return dados;
        }
    }
}
