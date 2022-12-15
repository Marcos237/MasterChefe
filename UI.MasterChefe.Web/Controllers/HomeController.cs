using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Diagnostics;
using System.Net;
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

        public async Task<IActionResult> Index()
        {
            using (var client = new HttpClient())
            {
                var response = await client.GetAsync($"https://localhost:44341/api/Receita");
                var responseString = await response.Content.ReadAsStringAsync();
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    var responseData = JsonConvert.DeserializeObject<ReceitaModel>(responseString);
                    return View(responseData);
                }
                return View();
            }
        }

        [HttpGet]
        public JsonResult BuscarPorId(int id)
        {
            var response = await client.GetAsync($"https://localhost:44341/api/Receita/id?");
            var responseString = await response.Content.ReadAsStringAsync();
            if (response.StatusCode == HttpStatusCode.OK)
            {
                var responseData = JsonConvert.DeserializeObject<ReceitaModel>(responseString);
                return View(responseData);
            }
            return View();
            return  Json(model);
        }

    }
}