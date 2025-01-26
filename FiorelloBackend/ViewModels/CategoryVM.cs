using FiorelloBackend.Models;

namespace FiorelloBackend.ViewModels
{
    public class CategoryVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool HasProduct { get; set; }
    }
}
