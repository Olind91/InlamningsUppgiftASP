using OskarLAspNet.Models.Dtos;

namespace OskarLAspNet.Models.Entities
{
    public class ProductCategoryEntity
    {
        public int Id { get; set; }
        public string CategoryName { get; set; } = null!;
        public ICollection<ProductEntity> Products { get; set; } = new HashSet<ProductEntity>();



        //Vill inte returna ProductCategoryEntity så därför skapas ProductCategory som vi sedan omvandlar med implicit så det inte behövs göra varje gång.
        public static implicit operator ProductCategory(ProductCategoryEntity entity)
        {
            if (entity != null) //1:28:30 f.10
            {
                return new ProductCategory
                {
                    Id = entity.Id,
                    CategoryName = entity.CategoryName,

                };
            }
            return null!;
        }
    }
}
