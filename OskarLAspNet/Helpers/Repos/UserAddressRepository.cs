using OskarLAspNet.Contexts;
using OskarLAspNet.Models.Entities;

namespace OskarLAspNet.Helpers.Repos
{
    public class UserAddressRepository : Repo<UserAddressEntity>
    {
        public UserAddressRepository(DataContext context) : base(context)
        {
        }
    }
}
