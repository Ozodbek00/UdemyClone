using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using Udemy.Data.DbContexts;
using Udemy.Data.IRepositories;

namespace Udemy.Data.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected readonly UdemyDbContext dbContext;
        protected readonly DbSet<T> dbSet;

        public Repository(UdemyDbContext dbContext)
        {
            this.dbContext = dbContext;
            this.dbSet = dbContext.Set<T>();
        }

        public async Task<T> AddAsync(T entity)
            => (await dbSet.AddAsync(entity)).Entity;

        public async Task DeleteAsync(Expression<Func<T, bool>> expression)
            => dbSet.Remove(await GetAsync(expression));

        public IQueryable<T> GetAll(Expression<Func<T, bool>> expression = null)
            => expression is null ? dbSet : dbSet.Where(expression);

        public async Task<T> GetAsync(Expression<Func<T, bool>> expression)
            => await GetAll(expression).FirstOrDefaultAsync();

        public async Task<T> UpdateAsync(T entity)
            => dbSet.Update(entity).Entity;
    }
}
