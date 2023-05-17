using Microsoft.AspNetCore.Mvc;
using OskarLAspNet.Helpers.Services;
using OskarLAspNet.Models.ViewModels;

namespace OskarLAspNet.Controllers
{
    public class ContactsController : Controller
    {
        private readonly ContactFormService _contactFormService;

        public ContactsController(ContactFormService contactFormService)
        {
            _contactFormService = contactFormService;
        }

        public IActionResult Index()
        {

            return View();
        }


        public async Task<IActionResult> SubmitContactForm(ContactFormVM viewModel)
        {
            if (ModelState.IsValid)
            {
                await _contactFormService.AddAsync(viewModel);
                // Optionally, you can perform additional actions or redirect to a "Thank You" page.

                return RedirectToAction("SubmitContactForm");
            }
            return View(viewModel);
        }
    }
}
