using FiorelloBackend.Data;
using FiorelloBackend.Models;
using FiorelloBackend.Services.Interfaces;
using FiorelloBackend.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FiorelloBackend.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppDbContext _context;
        private readonly ISliderService _sliderService;
        private readonly IBlogService _blogService;
        private readonly ICategoryService _categoryService;
        private readonly IProductService _productService;

        public HomeController(AppDbContext context,
                              ISliderService sliderService,
                              IBlogService blogService,
                              ICategoryService categoryService,
                              IProductService productService)
        {
            _context = context;
            _sliderService = sliderService;
            _blogService = blogService;
            _categoryService = categoryService;
            _productService = productService;
        }
        public async Task<IActionResult>  Index()
        {
            SliderVM slider = await _sliderService.GetAllAsync();

            IEnumerable<BlogVM> blogs = await _blogService.GetAllAsync(3);

            IEnumerable<CategoryVM> categories = await _categoryService.GetAllAsync();

            IEnumerable<ProductVM> products = await _productService.GetAllAsync();

            return View(new HomeVM
            {
                Slider = slider,
                Blogs = blogs,
                Categories = categories,
                Products = products
            });
        }

    }
}
