using FiorelloBackend.Data;
using FiorelloBackend.Services.Interfaces;
using FiorelloBackend.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace FiorelloBackend.Services
{
    public class ProductService : IProductService
    {
        private readonly AppDbContext _context;
        public ProductService(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<ProductVM>> GetAllAsync()
        {
            return await _context.Products.Include(m => m.ProductImages).Select(m => new ProductVM
            {
                Id = m.Id,
                Name = m.Name,
                Price = m.Price,
                CategoryId = m.CategoryId,
                ProductImages = m.ProductImages.Select(m=>new ProductImageVM
                {
                    Name = m.Name,
                    IsMain = m.IsMain,
                }).ToList()

            }).ToListAsync();
        }

        public async Task<ProductDetailVM> GetByIdAsync(int id)
        {
            var product = await _context.Products.Include(m => m.ProductImages)
                                                 .Include(m => m.Category)
                                                 .FirstOrDefaultAsync(m=>m.Id == id);

            if (product is null) return null;

            return new ProductDetailVM
            {
                Id = id,
                Name = product.Name,
                Price = product.Price,
                Description = product.Description,
                CategoryName = product.Category.Name,
                ProductImages = product.ProductImages.Select(m => new ProductImageVM
                {
                    Name = m.Name,
                    IsMain = m.IsMain,
                })
            };
        }
    }
}
