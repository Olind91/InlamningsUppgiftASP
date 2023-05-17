using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OskarLAspNet.Helpers.Services;
using OskarLAspNet.Models.ViewModels;

namespace OskarLAspNet.Controllers
{
    public class TagsController : Controller
    {
        private readonly TagService _tagService;

        public TagsController(TagService tagService)
        {
            _tagService = tagService;
        }



        [Authorize(Roles = "admin")]
        public async Task<IActionResult> Create(TagRegVM viewModel)
        {
            if (ModelState.IsValid)
            {
                //1:34:00 ish f.10.
                var tag = await _tagService.GetTagAsync(viewModel.TagName);
                if (tag != null)
                    //409
                    return Conflict(new { tag, error = "This tag already exists mylord." });

                tag = await _tagService.CreateTagAsync(viewModel);
                if (tag != null)

                    //201
                    return Created("", tag);
            }

            return View();
        }

        [Authorize(Roles = "admin")]
        public async Task<IActionResult> Index(string? tag) //1:50:00 ish f.10
        {
            //Hämtar specifik
            if (!string.IsNullOrEmpty(tag))
            {
                var _tag = await _tagService.GetTagAsync(tag);
                if (_tag != null)
                    return Ok(_tag); //200
            }
            else
            {
                //Om inte sökkriterie är ifyllt, hämtar alla.
                var tags = await _tagService.GetAllTagsAsync();
                if (tags != null)
                    return Ok(tags); //200
            }

            return NotFound(new { tag, error = "This is not the tag you are looking for, are you sure it exists?" }); //404
        }
    }
}
