using Udemy.Data.DbContexts;
using Udemy.Data.IRepositories;
using Udemy.Domain.Entities;

namespace Udemy.Data.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly UdemyDbContext dbContext;

        public IRepository<User> Users { get; }

        public UnitOfWork(UdemyDbContext dbContext)
        {
            this.dbContext = dbContext;

            Users = new Repository<User>(this.dbContext);
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public async Task SaveChangesAsync()
        {
            await dbContext.SaveChangesAsync();
        }
    }
}
