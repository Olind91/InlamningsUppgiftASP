using Microsoft.AspNetCore.Mvc.Rendering;
using OskarLAspNet.Helpers.Repos;
using OskarLAspNet.Models.Dtos;
using OskarLAspNet.Models.Entities;
using OskarLAspNet.Models.ViewModels;

namespace OskarLAspNet.Helpers.Services
{
    //Overloads inte alltid nödvändiga.

    public class TagService
    {
        private readonly TagRepo _tagRepo;

        public TagService(TagRepo tagRepo)
        {
            _tagRepo = tagRepo;
        }


        #region Create
        public async Task<Tag> CreateTagAsync(string tagName)
        {
            var entity = new TagEntity { TagName = tagName };
            var result = await _tagRepo.AddAsync(entity);

            return result;
        }

        //Runt 1 timme in i föreläsning 10
        public async Task<Tag> CreateTagAsync(TagRegVM viewModel)
        {

            var result = await _tagRepo.AddAsync(viewModel);
            return result;
        }
        #endregion

        #region Get
        public async Task<Tag> GetTagAsync(string tagName)
        {
            var result = await _tagRepo.GetAsync(x => x.TagName == tagName);
            return result;


            //1:40:50 f.10. lägger till get med schema också.
        }
        #endregion


        #region Get All
        public async Task<IEnumerable<Tag>> GetAllTagsAsync()
        {
            var result = await _tagRepo.GetAllAsync();

            //Behöver omvandla till lista då det annars hämtas som TagEntity
            var list = new List<Tag>();
            foreach (var tag in result)
                list.Add(tag);

            return list;
        }
        #endregion

        #region Update
        public async Task<Tag> UpdateTagAsync(Tag tag)
        {
            //Hämtar tag via ID, om tag id finns, uppdaterar.
            var entity = await _tagRepo.GetAsync(x => x.Id == tag.Id);
            if (entity != null)
            {
                entity.TagName = tag.TagName;
                var result = await _tagRepo.UpdateAsync(entity);
                return result;
            }

            return null!;
        }
        #endregion

        #region Delete
        //1:10:00 Föreläsning 10.
        //Olika kriterier för att kunna delete

        //Efter ID
        public async Task<bool> DeleteTagAsync(int id)
        {

            var entity = await _tagRepo.GetAsync(x => x.Id == id);
            return await _tagRepo.DeleteAsync(entity);
        }

        //Efter Namn
        public async Task<bool> DeleteTagAsync(string tagName)
        {

            var entity = await _tagRepo.GetAsync(x => x.TagName == tagName);
            return await _tagRepo.DeleteAsync(entity);
        }

        //Hel Tag
        public async Task<bool> DeleteTagAsync(Tag tag)
        {

            var entity = await _tagRepo.GetAsync(x => x.Id == tag.Id);
            return await _tagRepo.DeleteAsync(entity);
        }

        #endregion



        //TEST
        public async Task<List<SelectListItem>> GetTagsAsync()
        {
            var tags = new List<SelectListItem>();



            foreach (var tag in await _tagRepo.GetAllAsync())
            {
                tags.Add(new SelectListItem
                {
                    Value = tag.Id.ToString(),
                    Text = tag.TagName



                });
            }
            return tags;
        }



        public async Task<List<SelectListItem>> GetTagsAsync(string[] selectedTags)
        {
            var tags = new List<SelectListItem>();



            foreach (var tag in await _tagRepo.GetAllAsync())
            {
                tags.Add(new SelectListItem
                {
                    Value = tag.Id.ToString(),
                    Text = tag.TagName,
                    Selected = selectedTags.Contains(tag.Id.ToString())



                });
            }
            return tags;
        }
    }
}