using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using OskarLAspNet.Helpers.Services;
using OskarLAspNet.Models.ViewModels;

namespace OskarLAspNet.Controllers
{
    public class RegisterController : Controller
    {

        private readonly AuthService _authService;

        public RegisterController(AuthService authService)
        {
            _authService = authService;
        }

        public IActionResult Index()
        {
            return View();
        }



        [HttpPost]
        public async Task<IActionResult> Index(UserRegisterVM viewModel)
        {
            if (ModelState.IsValid)
            {
                //Kollar om user finns, true/false
                if (await _authService.UserAlreadyExistsAsync(x => x.Email == viewModel.Email))
                    ModelState.AddModelError("", "A user with the same email already exists");

                //registrerar och omdirigerar
                if (await _authService.RegisterUserAsync(viewModel))
                    return RedirectToAction("index", "login");

            }
            return View(viewModel);
        }
    }
}
