using Microsoft.AspNetCore.Mvc;

namespace OskarLAspNet.Controllers
{
    public class AccessDeniedController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
