using Microsoft.EntityFrameworkCore;
using OskarLAspNet.Models.Identity;

namespace OskarLAspNet.Models.Entities
{
    //Slår ihop till en primär nyckel.
    [PrimaryKey(nameof(UserId), nameof(AddressId))]
    public class UserAddressEntity
    {
        //Kopplar till respektive sida
        public string UserId { get; set; } = null!;
        public AppUser User { get; set; } = null!;




        public int AddressId { get; set; }
        public AddressEntity Address { get; set; } = null!;
    }
}
