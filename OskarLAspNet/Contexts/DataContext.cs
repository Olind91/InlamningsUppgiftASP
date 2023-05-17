using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using OskarLAspNet.Models.Entities;
using OskarLAspNet.Models.Identity;

namespace OskarLAspNet.Contexts
{
    public class DataContext : IdentityDbContext<AppUser>
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        //Users
        public DbSet<AddressEntity> Adresses { get; set; }
        public DbSet<UserAddressEntity> UserAddresses { get; set; }

        //ContactForm
        public DbSet<ContactFormEntryEntity> ContactFormEntries { get; set; }

        //Products
        public DbSet<ProductEntity> Products { get; set; }
        public DbSet<TagEntity> Tags { get; set; }
        public DbSet<ProductCategoryEntity> ProductCategories { get; set; }
        public DbSet<ProductTagEntity> ProductTags { get; set; }
    }
}
