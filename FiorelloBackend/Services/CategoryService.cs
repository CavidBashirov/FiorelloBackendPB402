using FiorelloBackend.Data;
using FiorelloBackend.Services.Interfaces;
using FiorelloBackend.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace FiorelloBackend.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly AppDbContext _context;
        public CategoryService(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<CategoryVM>> GetAllAsync()
        {
            return await _context.Categories.Include(m=>m.Products).Select(c => new CategoryVM
            {
                Id = c.Id,
                Name = c.Name,
                HasProduct = c.Products.Any(),
            }).ToListAsync();
        }
    }
}
