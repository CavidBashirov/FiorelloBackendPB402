using Microsoft.AspNetCore.Mvc;

namespace FiorelloBackend.Controllers
{
    public class ErrorController : Controller
    {
        public IActionResult NotFoundException()
        {
            return View();
        }
    }
}
