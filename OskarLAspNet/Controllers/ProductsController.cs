using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OskarLAspNet.Helpers.Services;
using OskarLAspNet.Models.ViewModels;

namespace OskarLAspNet.Controllers
{
    public class ProductsController : Controller
    {
        private readonly ProductService _productService;

        public ProductsController(ProductService productService)
        {
            _productService = productService;
        }




        [Authorize(Roles = "admin")]
        public async Task<IActionResult> Create(ProductRegVM viewModel)
        {
            if (ModelState.IsValid)
            {
                var product = await _productService.CreateProductAsync(viewModel);
                if (product != null)
                {
                    if (viewModel.Image != null)
                        await _productService.UploadImageAsync(product, viewModel.Image);
                    // await _productService.CreateProductAsync(viewModel);
                    return RedirectToAction("Index");

                }

                ModelState.AddModelError("", "Something Went Wrong.");
            }
            return View();
        }

        public async Task<IActionResult> ProductDetails(ProductRegVM viewModel)
        {
            var product = await _productService.GetProductAsync(viewModel.ArticleNumber);

            if (product != null)
            {
                
                viewModel.ProductName = product.ProductName;
                viewModel.ProductDescription = product.ProductDescription;
                

                return View(viewModel);
            }
            return View();
        }

        public async Task<IActionResult> Index()
        {
            var products = await _productService.GetAllAsync();
            return View(products);
        }
    }
}
