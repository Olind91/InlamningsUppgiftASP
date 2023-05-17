using OskarLAspNet.Helpers.Repos;
using OskarLAspNet.Models.Dtos;
using OskarLAspNet.Models.Entities;
using OskarLAspNet.Models.ViewModels;

namespace OskarLAspNet.Helpers.Services
{
    public class ProductCategoryService
    {
        private readonly ProductCategoryRepo _productCategoryRepo;

        public ProductCategoryService(ProductCategoryRepo productCategoryRepo)
        {
            _productCategoryRepo = productCategoryRepo;
        }

        #region Create
        public async Task<ProductCategory> CreateProductCategoryAsync(string categoryName)
        {
            var entity = new ProductCategoryEntity { CategoryName = categoryName };
            var result = await _productCategoryRepo.AddAsync(entity);

            return result;

        }

        public async Task<ProductCategory> CreateProductCategoryAsync(CategoryRegVM viewModel)
        {
            var result = await _productCategoryRepo.AddAsync(viewModel);
            return result;
        }
        #endregion


        #region Get
        public async Task<ProductCategory> GetCategoryAsync(string categoryName)
        {
            var result = await _productCategoryRepo.GetAsync(x => x.CategoryName == categoryName);
            return result;
        }

        public async Task<ProductCategory> GetCategoryAsync(int id)
        {
            var result = await _productCategoryRepo.GetAsync(x => x.Id == id);
            return result;


            //1:40:50 f.10. lägger till get med schema också.
        }
        #endregion


        #region Get All
        public async Task<IEnumerable<ProductCategory>> GetCategoriesAsync()
        {
            var result = await _productCategoryRepo.GetAllAsync();


            var list = new List<ProductCategory>();
            foreach (var category in result)
                list.Add(category);

            return list;
        }
        #endregion


        //lägg till update + delete, ta från tagservice.
    }
}
