using FiorelloBackend.ViewModels;

namespace FiorelloBackend.Services.Interfaces
{
    public interface IProductService
    {
        Task<IEnumerable<ProductVM>> GetAllAsync();
        Task<ProductDetailVM> GetByIdAsync(int id);
    }
}
