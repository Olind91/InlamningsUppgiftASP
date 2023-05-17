using Microsoft.EntityFrameworkCore.Metadata.Internal;
using OskarLAspNet.Models.Dtos;
using OskarLAspNet.Models.Interfaces;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace OskarLAspNet.Models.Entities
{
    public class ProductEntity : IProduct
    {
        [Key]
        public string ArticleNumber { get; set; } = null!;
        public string ProductName { get; set; } = null!;
        public string? ProductDescription { get; set; }


        [Column(TypeName = "money")]
        public decimal? Price { get; set; }
        public string? ImageUrl { get; set; }


        public int ProductCategoryId { get; set; }
        public ProductCategoryEntity ProductCategory { get; set; } = null!;

        public ICollection<ProductTagEntity> ProductTags { get; set; } = new HashSet<ProductTagEntity>();



        public static implicit operator Product(ProductEntity entity)
        {
            if (entity != null)
            {
                return new Product
                {
                    ArticleNumber = entity.ArticleNumber,
                    ProductName = entity.ProductName,
                    ProductDescription = entity.ProductDescription,
                    Price = entity.Price,
                    ProductCategory = entity.ProductCategory,
                    ImageUrl = entity.ImageUrl,

                };
            }
            return null!;
        }
    }
}
