using System.Collections.Generic;

namespace FiorelloBackend.ViewModels
{
    public class SliderVM
    {
        public IEnumerable<string> SliderImages { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Img { get; set; }
    }
}
