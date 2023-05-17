using OskarLAspNet.Contexts;
using OskarLAspNet.Models.Entities;

namespace OskarLAspNet.Helpers.Repos
{
    public class ProductTagRepo : Repo<ProductTagEntity>
    {
        public ProductTagRepo(DataContext context) : base(context)
        {
        }
    }
}
