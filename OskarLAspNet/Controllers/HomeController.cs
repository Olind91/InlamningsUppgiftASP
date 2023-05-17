using Microsoft.AspNetCore.Mvc;
using OskarLAspNet.Helpers.Services;
using OskarLAspNet.Models.ViewModels;

namespace OskarLAspNet.Controllers
{
    public class HomeController : Controller
    {
        private readonly ProductService _productService;

        public HomeController(ProductService productService)
        {
            _productService = productService;
        }

       


        //TEST
        public IActionResult Index()
        {
            //Ändra nummer beroende på Tag. 1 = new. 2 = featured. 3 = popular
            var products = _productService.GetProductsByTagId(18);

            return View(products);
        }


    }
}
