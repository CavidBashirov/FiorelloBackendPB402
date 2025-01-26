using FiorelloBackend.Data;
using FiorelloBackend.Models;
using FiorelloBackend.Services.Interfaces;
using FiorelloBackend.ViewModels;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FiorelloBackend.Services
{
    public class BlogService : IBlogService
    {
        private readonly AppDbContext _context;
        public BlogService(AppDbContext context)
        {
            _context = context;  
        }
        public async Task<IEnumerable<BlogVM>> GetAllAsync(int? take = null)
        {
            IEnumerable<Blog> dbBlogs = new List<Blog>();
            if (take is null)
                dbBlogs = await _context.Blogs.ToListAsync();
            else
                dbBlogs = await _context.Blogs.Take((int)take).ToListAsync();


            IEnumerable<BlogVM> blogs = dbBlogs.Select(m => new BlogVM
            {
                Id = m.Id,
                Title = m.Title,
                Description = m.Description,
                Image = m.Image,

            }).ToList();

            return blogs;
        }

        public async Task<BlogVM> GetByIdAsync(int id)
        {
            var blog = await _context.Blogs.FirstOrDefaultAsync(m => m.Id == id);
            return new BlogVM
            {
                Id = blog.Id,
                Title = blog.Title,
                Description = blog.Description,
                Image = blog.Image,
            };
        }
    }
}
