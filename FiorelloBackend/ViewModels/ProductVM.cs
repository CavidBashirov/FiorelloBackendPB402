namespace FiorelloBackend.ViewModels
{
    public class ProductVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int CategoryId { get; set; }
        public IEnumerable<ProductImageVM> ProductImages { get; set; }
    }
}
