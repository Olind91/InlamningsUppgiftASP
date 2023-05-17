using OskarLAspNet.Contexts;
using OskarLAspNet.Models.Entities;

namespace OskarLAspNet.Helpers.Repos
{
    public class AddressRepository : Repo<AddressEntity>
    {
        public AddressRepository(DataContext context) : base(context)
        {
        }
    }
}
