using Microsoft.AspNetCore.Mvc;
using UI.MasterChefe.Web.Models;

namespace UI.MasterChefe.Web.Controllers
{
    public class IngredienteController : Controller
    {
        private IWebHostEnvironment webHostEnvironment;
        private readonly IConfiguration configuration;

        public IngredienteController(IWebHostEnvironment webHostEnvironment, IConfiguration configuration)
        {
            this.webHostEnvironment = webHostEnvironment;
            this.configuration = configuration;
        }

        [HttpGet]
        public IActionResult BuscarPorReceitaId(int id)
        {
            IngredienteModel model = new IngredienteModel();
            return View("Cadastro", model);
        }

        [HttpPost]
        public async Task<IActionResult> Cadastro(ReceitaModel model)
        {

            if (ModelState.IsValid)
            {

                var teste = new ReceitaModel()
                {
                    id = 52,
                    descricao = model.descricao,
                    dataCadastro = DateTime.Now,
                    imagem = model.imagem,
                    modoFazer = model.modoFazer,
                    titulo = model.titulo
                };



                model.receitas = new List<ReceitaModel>();
                model.receitas.Add(teste);
            }
            return View("Cadastro", model);
        }

        [HttpGet]
        public IActionResult Editar(int id)
        {
            var model = new ReceitaModel()
            {

                id = id,
                descricao = "teste",
                dataCadastro = DateTime.Now,
                imagem = "teste",
                modoFazer = "teste",
                titulo = "teste"
            };
            var teste = new ReceitaModel()
            {
                id = id,
                descricao = "teste",
                dataCadastro = DateTime.Now,
                imagem = "teste",
                modoFazer = "teste",
                titulo = "teste"
            };

            model.receitas = new List<ReceitaModel>();
            model.receitas.Add(teste);

            return View("Cadastro", model);
        }


        [HttpGet]
        public async Task<JsonResult> BuscarPorId(int id)
        {

            var model = new ReceitaModel()
            {

                id = 52,
                descricao = "teste",
                dataCadastro = DateTime.Now,
                imagem = "teste",
                modoFazer = "teste",
                titulo = "teste"
            };
            return Json(model);

        }

        [HttpPost]
        public IActionResult Excluir(ReceitaModel model)
        {

            return View("Cadastro", new ReceitaModel());
        }
    }
}
