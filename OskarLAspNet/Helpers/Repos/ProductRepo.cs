using Microsoft.EntityFrameworkCore;
using OskarLAspNet.Contexts;
using OskarLAspNet.Models.Entities;
using System.Linq.Expressions;

namespace OskarLAspNet.Helpers.Repos
{
    public class ProductRepo : Repo<ProductEntity>
    {
        //Ärver all funktionalitet som finns i Repo.cs
        //Går att skriva över funktioner med "Generate overrides"

        private readonly DataContext _context;

        public ProductRepo(DataContext context) : base(context)
        {
            _context = context;
        }

        public override async Task<ProductEntity> GetAsync(Expression<Func<ProductEntity, bool>> expression)
        {
            //2:50:00 f.10
            var entity = await _context.Products
                  .Include(x => x.ProductCategory)
                  .Include(x => x.ProductTags)
                  .ThenInclude(x => x.Tag)
                  .FirstOrDefaultAsync(expression);
            if (entity != null)
                return entity!;

            return null!;
        }



        //TEST
        public IEnumerable<ProductEntity> GetProductsByTagId(int tagId)
        {
            return _context.ProductTags
                .Where(pt => pt.TagId == tagId)
                .Select(pt => pt.Product)
                .ToList();
        }
    }
}
