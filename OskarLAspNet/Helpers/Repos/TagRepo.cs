using OskarLAspNet.Contexts;
using OskarLAspNet.Models.Entities;

namespace OskarLAspNet.Helpers.Repos
{
    public class TagRepo : Repo<TagEntity>
    {
        public TagRepo(DataContext context) : base(context)
        {
        }
    }
}
