using FiorelloBackend.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FiorelloBackend.Services.Interfaces
{
    public interface IBlogService
    {
        Task<IEnumerable<BlogVM>> GetAllAsync(int? take = null);
        Task<BlogVM> GetByIdAsync(int id);
    }
}
