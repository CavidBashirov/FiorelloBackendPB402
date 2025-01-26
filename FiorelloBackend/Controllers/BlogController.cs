using FiorelloBackend.Data;
using FiorelloBackend.Models;
using FiorelloBackend.Services.Interfaces;
using FiorelloBackend.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace FiorelloBackend.Controllers
{
    public class BlogController : Controller
    {
        private readonly IBlogService _blogService;
        public BlogController(IBlogService blogService)
        {
            _blogService = blogService;
        }
        public async Task<IActionResult> Index()
        {
            var blogs = await _blogService.GetAllAsync();

            ViewBag.Count = blogs.Count();

            return View(await _blogService.GetAllAsync(6));
        }

        public async Task<IActionResult> Detail(int id)
        {
            BlogVM blog = await _blogService.GetByIdAsync(id);
            return View(blog);
        }
        public async Task<IActionResult> ShowMore(int skip)
        {
            var blogs = await _blogService.GetAllAsync();

            var filteredBlogs = blogs.Skip(skip).Take(3).ToList();

            int count = 5;

            return PartialView("_BlogPartial", filteredBlogs);

        }
    }
}
