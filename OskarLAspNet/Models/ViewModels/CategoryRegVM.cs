using OskarLAspNet.Models.Entities;

namespace OskarLAspNet.Models.ViewModels
{
    public class CategoryRegVM
    {
        public string CategoryName { get; set; } = null!;


        public static implicit operator ProductCategoryEntity(CategoryRegVM viewModel)
        {
            return new ProductCategoryEntity
            {
                CategoryName = viewModel.CategoryName

            };
        }
    }
}
