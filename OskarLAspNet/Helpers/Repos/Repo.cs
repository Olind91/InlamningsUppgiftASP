using Microsoft.EntityFrameworkCore;
using OskarLAspNet.Contexts;
using System.Linq.Expressions;

namespace OskarLAspNet.Helpers.Repos
{
    public abstract class Repo<TEntity> where TEntity : class
    {
        private readonly DataContext _context;

        protected Repo(DataContext context)
        {
            _context = context;
        }




        /*TEntity anpassar sig och blir entiteten som används. (ex. ProductCategoryEntity/TagEntity m.m.)
         Tänk på att använda namnen som är satta i DataContext.

        _context.Set<TEntity>().Add(entity); => _context.ProductCategories.Add(entity);        
        */


        /* 
         (Expression<Func<TEntity, bool>> expression) Sätts generellt så att man kan anpassa hur man vill hämta data beroende på tillfälle
         
        x => x.ArticleNumber == articleNumber                 
        product => product.ArticleNumber == articlenumber

         */


        #region Create
        public virtual async Task<TEntity> AddAsync(TEntity entity)
        {
            _context.Set<TEntity>().Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }
        #endregion



        #region Get specific
        public virtual async Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> expression)
        {
            var item = await _context.Set<TEntity>().FirstOrDefaultAsync(expression);
            return item!;

        }
        #endregion

        #region Get all

        //Hämtar alla 
        public virtual async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            try
            {
                var items = await _context.Set<TEntity>().ToListAsync();
                return items!;
            }
            catch { return null!; }

        }


        //Hämtar alla efter specifik sökkriterie
        public virtual async Task<IEnumerable<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> expression)
        {
            try
            {
                var items = await _context.Set<TEntity>().Where(expression).ToListAsync();
                return items!;
            }
            catch { return null!; }

        }
        #endregion


        #region Update
        public virtual async Task<TEntity> UpdateAsync(TEntity entity)
        {
            try
            {
                _context.Set<TEntity>().Update(entity);
                await _context.SaveChangesAsync();
                return entity;
            }
            catch { return null!; }
        }
        #endregion


        #region Delete
        public virtual async Task<bool> DeleteAsync(TEntity entity)
        {
            try
            {
                _context.Set<TEntity>().Remove(entity);
                await _context.SaveChangesAsync();
                return true;
            }
            catch { return false; }

        }
        #endregion
    }
}
