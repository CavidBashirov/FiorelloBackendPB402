using Microsoft.AspNetCore.Mvc;

namespace FiorelloBackend.Controllers
{
    public class ShopController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
