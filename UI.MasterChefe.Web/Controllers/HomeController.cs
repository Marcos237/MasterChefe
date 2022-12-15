using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
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
                var response = await client.GetAsync($"https://localhost:7043/api/Receita");
                var responseString = await response.Content.ReadAsStringAsync();
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    var responseData = JsonConvert.DeserializeObject<List<ReceitaModel>>(responseString);
                    return View(responseData);
                }
                return View();
            }
        }

        [HttpGet]
        public async Task<JsonResult> BuscarPorId(int id)
        {
            using (var client = new HttpClient())
            {
                var response = await client.GetAsync($"https://localhost:7043/api/Receita/id?");
                var responseString = await response.Content.ReadAsStringAsync();
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    var responseData = JsonConvert.DeserializeObject<ReceitaModel>(responseString);
                    return Json(responseData);
                }
                return Json(null);
            }
        }
    }
}