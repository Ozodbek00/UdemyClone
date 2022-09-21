using System.Linq.Expressions;
using Udemy.Domain.Entities;
using Udemy.Service.DTOs;

namespace Udemy.Service.IServices
{
    public interface IUserService
    {
        Task<IEnumerable<User>> GetAllAsync(Expression<Func<User, bool>> expression = null);
        Task<User> GetAsync(Expression<Func<User, bool>> expression);
        Task<User> AddAsync(UserForCreation dto);
        Task<User> UpdateAsync(long id, UserForCreation dto);
        Task<bool> DeleteAsync(Expression<Func<User, bool>> expression);
    }
}
