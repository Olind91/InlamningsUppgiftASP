using OskarLAspNet.Models.Dtos;
using OskarLAspNet.Models.Entities;
using System.ComponentModel.DataAnnotations;

namespace OskarLAspNet.Models.ViewModels
{
    public class ProductRegVM
    {
        public string ArticleNumber { get; set; } = null!;
        public string ProductName { get; set; } = null!;
        public string? ProductDescription { get; set; }
        public decimal? Price { get; set; }

        [DataType(DataType.Upload)]
        public IFormFile? Image { get; set; }

               
        public List<string> Tags { get; set; } = new List<string>();

        public int CategoryID { get; set; }




        public static implicit operator ProductEntity(ProductRegVM viewModel)
        {
            var entity = new ProductEntity
            {

                ArticleNumber = viewModel.ArticleNumber,
                ProductName = viewModel.ProductName,
                ProductDescription = viewModel.ProductDescription,
                Price = viewModel.Price,
                ProductCategoryId = viewModel.CategoryID

                //ProductTags = (ICollection<ProductTagEntity>)viewModel.Tags,
            };

            if (viewModel.Image != null)

                entity.ImageUrl = $"{Guid.NewGuid}_{viewModel.Image?.FileName}";

            return entity;



        }
    }
}
