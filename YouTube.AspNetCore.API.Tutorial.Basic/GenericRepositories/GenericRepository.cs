using Microsoft.EntityFrameworkCore;
using YouTube.AspNetCore.API.Tutorial.Basic.Context;

namespace YouTube.AspNetCore.API.Tutorial.Basic.GenericRepositories
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity>
       where TEntity : class
    {
        private readonly AppDbContext _context;
        private readonly DbSet<TEntity> _dbSet;

        public GenericRepository(AppDbContext customContext)
        {
            _context = customContext;
            _dbSet = _context.Set<TEntity>();
        }

        public void CreateItem(TEntity request)
        {
            _dbSet.Add(request);
            _context.SaveChanges();
        }

        public void DeleteItem(TEntity request)
        {
            _dbSet.Remove(request);
            _context.SaveChanges();
        }

        public IQueryable<TEntity> GetAll()
        {
            var items = _dbSet.AsQueryable().AsNoTracking();
            return items;
        }

        public TEntity GetItemById(int id)
        {
            var item = _dbSet.Find(id);
            return item;
        }

        public void UpdateItem(TEntity request)
        {
            _dbSet.Update(request);
            _context.SaveChanges();
        }
    }
}
