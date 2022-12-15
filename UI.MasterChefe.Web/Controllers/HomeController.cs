using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using UI.MasterChefe.Web.Models;

namespace UI.MasterChefe.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            ReceitaModel model = new ReceitaModel();

            model.id = 1;
            model.titulo = "teste";
            model.imagem = "teste.jpg";
            ReceitaModel model2 = new ReceitaModel();

            model.id = 2;
            model.titulo = "teste";
            model.imagem = "teste.jpg";
            ReceitaModel model3 = new ReceitaModel();

            model.id = 3;
            model.titulo = "teste";
            model.imagem = "teste.jpg";
            ReceitaModel model4 = new ReceitaModel();

            model.id = 4;
            model.titulo = "teste";
            model.imagem = "teste.jpg";

            IEnumerable<ReceitaModel> lista;
            lista = new List<ReceitaModel> { model, model2, model3, model4};
            return View(lista);
        }

        [HttpGet]
        public JsonResult BuscarPorId(int id)
        {
            ReceitaModel model = new ReceitaModel();

            model.titulo = "teste";
            model.imagem = "teste.jpg";
            model.descricao = "teste.jpg";
            model.modoFazer = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.";
            model.ingredientes = new List<IngredienteModel>() { new IngredienteModel() { id = 1, descricao = "colheres", Nome = "testze", peso = 0, quantidade = 2, receitaId = 1 } };
            return  Json(model);
        }

    }
}