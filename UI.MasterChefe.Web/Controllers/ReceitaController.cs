using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net;
using System.Reflection;
using System.Text;
using UI.MasterChefe.Web.Models;

namespace UI.MasterChefe.Web.Controllers
{

    public class ReceitaController : Controller
    {

        private IWebHostEnvironment webHostEnvironment;
        private readonly IConfiguration configuration;
        private string pathImagem;
        private string conexao;
        public ReceitaController(IWebHostEnvironment webHostEnvironment, IConfiguration configuration)
        {
            this.webHostEnvironment = webHostEnvironment;
            this.configuration = configuration;
            pathImagem = configuration["pathImagem"] ?? "";
            conexao = configuration["apiUrl"] ?? "";
        }

        [HttpGet]
        public async Task<IActionResult> Cadastro()
        {
            ReceitaModel model = new ReceitaModel();
            ViewBag.id = 0;
            using (var client = new HttpClient())
            {
                var response = await client.GetAsync($"{conexao}/Receita");
                var responseString = await response.Content.ReadAsStringAsync();
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    var responseData = JsonConvert.DeserializeObject<List<ReceitaModel>>(responseString);
                    model.receitas = responseData;
                    return View(model);
                }
                return View();
            }
        }

        [HttpPost]
        public async Task<IActionResult> Cadastro(ReceitaModel model)
        {

            if (ModelState.IsValid)
            {

                using (var client = new HttpClient())
                {
                    if (model.id == 0)
                    {
                        model.imagem = await SalvarImagem(model);
                        var content = new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json");
                        var response = await client.PostAsync($"{conexao}/Receita", content);
                        var responseString = await response.Content.ReadAsStringAsync();
                        if (response.StatusCode == HttpStatusCode.OK)
                        {
                            var responseData = JsonConvert.DeserializeObject<ReceitaModel>(responseString);
                            return RedirectToAction("Cadastro");
                        }
                    }
                    else
                    {
                        model.imagem = await SalvarImagem(model);
                        var content = new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json");
                        var response = await client.PutAsync($"{conexao}/Receita", content);
                        var responseString = await response.Content.ReadAsStringAsync();
                        if (response.StatusCode == HttpStatusCode.OK)
                        {
                            var responseData = JsonConvert.DeserializeObject<ReceitaModel>(responseString);
                            return RedirectToAction("Cadastro");
                        }
                    }

                    return View();
                }
            }
            return View("Cadastro", model);
        }

        [HttpGet]
        public async Task<IActionResult> Editar(int id)
        {
            ViewBag.id = id;
            using (var client = new HttpClient())
            {
                var response = await client.GetAsync($"{conexao}/Receita/{id}");
                var responseString = await response.Content.ReadAsStringAsync();

                if (response.StatusCode == HttpStatusCode.OK)
                {
                    var responseList = await client.GetAsync($"{conexao}/Receita");
                    var responseStringList = await responseList.Content.ReadAsStringAsync();
                    var responseDataList = JsonConvert.DeserializeObject<List<ReceitaModel>>(responseStringList);

                    var responseData = JsonConvert.DeserializeObject<ReceitaModel>(responseString);
                    responseData.receitas = responseDataList ?? new List<ReceitaModel>();
                    return View("Cadastro", responseData);
                }
                return View();
            }
        }


        [HttpGet]
        public async Task<JsonResult> BuscarPorId(int id)
        {
            using (var client = new HttpClient())
            {
                var response = await client.GetAsync($"{conexao}/Receita/{id}");
                var responseString = await response.Content.ReadAsStringAsync();
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    var responseData = JsonConvert.DeserializeObject<ReceitaModel>(responseString);
                    return Json(responseData);
                }
                return Json(null);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Excluir(ReceitaModel model)
        {
            using (var client = new HttpClient())
            {
                var response = await client.DeleteAsync($"{conexao}/Receita/{model.id}");
                var responseString = await response.Content.ReadAsStringAsync();
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    return RedirectToAction("Cadastro");
                }
                return Json(null);
            }
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
