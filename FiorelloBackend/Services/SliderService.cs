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
    public class SliderService : ISliderService
    {
        private readonly AppDbContext _context;

        public SliderService(AppDbContext context)
        {
            _context = context;
        }
        public async Task<SliderVM> GetAllAsync()
        {
            IEnumerable<string> sliders = await _context.Sliders.Select(m=>m.Image).ToListAsync();
            SliderInfo sliderInfo = await _context.SliderInfos.FirstOrDefaultAsync();
            return new SliderVM { SliderImages = sliders , Description = sliderInfo.Description, Img = sliderInfo.Img, Title = sliderInfo.Title};
        }
    }
}
