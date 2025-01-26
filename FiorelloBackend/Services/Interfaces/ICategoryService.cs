using FiorelloBackend.ViewModels;

namespace FiorelloBackend.Services.Interfaces
{
    public interface ICategoryService
    {
        Task<IEnumerable<CategoryVM>> GetAllAsync();
    }
}
