using FiorelloBackend.ViewModels;
using System.Threading.Tasks;

namespace FiorelloBackend.Services.Interfaces
{
    public interface ISliderService
    {
        Task<SliderVM> GetAllAsync();
    }
}
