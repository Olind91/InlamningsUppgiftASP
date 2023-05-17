using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OskarLAspNet.Helpers.Services;
using OskarLAspNet.Models.Dtos;
using OskarLAspNet.Models.ViewModels;

namespace OskarLAspNet.Controllers
{
    public class ProductsController : Controller
    {
        private readonly ProductService _productService;
        private readonly TagService _tagService;

        public ProductsController(ProductService productService, TagService tagService)
        {
            _productService = productService;
            _tagService = tagService;
        }

        public async Task<IActionResult> Index()
        {
            var products = await _productService.GetAllAsync();
            return View(products);
        }




        public async Task<IActionResult> Create()
        {
            ViewBag.Tags = await _tagService.GetTagsAsync();



            return View();
        }



        [HttpPost]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> Create(ProductRegVM viewModel, string[] tags)
        {
            if (ModelState.IsValid)
            {
                var product = await _productService.CreateAsync(viewModel);
                if (product != null)
                {
                    if (viewModel.Image != null)
                        await _productService.UploadImageAsync(product, viewModel.Image);

                    await _productService.AddProductTagsAsync(viewModel, tags);

                    return RedirectToAction("Create");
                }

                ModelState.AddModelError("", "Something Went Wrong.");
            }

            ViewBag.Tags = await _tagService.GetTagsAsync();
            return View(viewModel);
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

        
    }
}
