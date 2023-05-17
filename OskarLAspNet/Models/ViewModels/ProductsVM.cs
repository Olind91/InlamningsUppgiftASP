using OskarLAspNet.Models.Dtos;

namespace OskarLAspNet.Models.ViewModels
{
    public class ProductsVM
    {
        public IEnumerable<Product> Products { get; set; } = new List<Product>();
    }
}
