using Udemy.Domain.Entities;

namespace Udemy.Data.IRepositories
{
    public interface IUnitOfWork: IDisposable
    {
        IRepository<User> Users { get; }

        Task SaveChangesAsync();
    }
}
