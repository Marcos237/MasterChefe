using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net;
using UI.MasterChefe.Web.Models;

namespace UI.MasterChefe.Web.Controllers
{

    public class ReceitaController : Controller
    {

        private IWebHostEnvironment webHostEnvironment;
        private readonly IConfiguration configuration;
        private string pathImagem;
        public ReceitaController(IWebHostEnvironment webHostEnvironment, IConfiguration configuration)
        {
            this.webHostEnvironment = webHostEnvironment;
            this.configuration = configuration;
            pathImagem = configuration["pathImagem"] ?? "";
        }

        [HttpGet]
        public IActionResult Cadastro()
        {
            ReceitaModel model = new ReceitaModel();
            return View("Cadastro", model);
        }

        [HttpPost]
        public async Task<IActionResult> Cadastro(ReceitaModel model)
        {

            if (ModelState.IsValid)
            {
                model.imagem = await SalvarImagem(model);

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



        [NonAction]
        public async Task<string> SalvarImagem(ReceitaModel model)
        {

            if (model.arquivo != null)
            {
                string path = Path.Combine(Directory.GetCurrentDirectory(), pathImagem);

                if (!Directory.Exists(path))
                    Directory.CreateDirectory(path);

                FileInfo fileInfo = new FileInfo(model.arquivo.FileName);
                model.imagem = model.arquivo.FileName;

                string fileNameWithPath = Path.Combine(path, model.imagem);

                using (var stream = new FileStream(fileNameWithPath, FileMode.Create))
                {
                    await model.arquivo.CopyToAsync(stream);
                }
            }

            return model.imagem ?? "";
        }
    }
}
