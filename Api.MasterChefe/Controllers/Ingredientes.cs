using Microsoft.AspNetCore.Mvc;

namespace Api.MasterChefe.Web.Controllers
{
    public class Ingredientes : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
