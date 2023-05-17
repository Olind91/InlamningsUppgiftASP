using OskarLAspNet.Contexts;
using OskarLAspNet.Models.Entities;

namespace OskarLAspNet.Helpers.Repos
{
    public class ContactFormRepo : Repo<ContactFormEntryEntity>
    {
        public ContactFormRepo(DataContext context) : base(context)
        {
        }
    }
}
