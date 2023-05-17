using Microsoft.AspNetCore.Mvc;
using OskarLAspNet.Helpers.Services;
using OskarLAspNet.Models.ViewModels;

namespace OskarLAspNet.Controllers
{
    public class LoginController : Controller
    {
        private readonly AuthService _authService;

        public LoginController(AuthService authService)
        {
            _authService = authService;
        }



        public IActionResult Index(string ReturnUrl = null!)
        {
            var viewModel = new UserLoginVM();
            if (ReturnUrl != null)
                viewModel.ReturnUrl = ReturnUrl;
            return View(viewModel);
        }




        //Logga in
        [HttpPost]

        public async Task <IActionResult> Index(UserLoginVM viewModel)
        {
            if (ModelState.IsValid)
            {
                if (await _authService.LoginAsync(viewModel))
                    return LocalRedirect(viewModel.ReturnUrl);
                ModelState.AddModelError("", "Incorrect email or password");
            }

            return View(viewModel);
        }
    }
}
