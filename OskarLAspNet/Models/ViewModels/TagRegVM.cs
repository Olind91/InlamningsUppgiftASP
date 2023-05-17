using OskarLAspNet.Models.Entities;

namespace OskarLAspNet.Models.ViewModels
{
    public class TagRegVM
    {
        public string TagName { get; set; } = null!;




        public static implicit operator TagEntity(TagRegVM viewModel)
        {
            return new TagEntity
            {
                TagName = viewModel.TagName,

            };
        }
    }
}
