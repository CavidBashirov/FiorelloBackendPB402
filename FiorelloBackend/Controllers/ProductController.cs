using FiorelloBackend.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FiorelloBackend.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }
        public async Task<IActionResult> Index(int? id)
        {
            if (id is null) return BadRequest();
            var product = await _productService.GetByIdAsync((int)id);

            if (product is null) return RedirectToAction("NotFoundException", "Error");

            return View(product);
        }
    }
}
