using AutoMapper;
using System.Linq.Expressions;
using Udemy.Data.IRepositories;
using Udemy.Domain.Entities;
using Udemy.Service.DTOs;
using Udemy.Service.IServices;

namespace Udemy.Service.Services
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public UserService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public async Task<User> AddAsync(UserForCreation dto)
        {
            var user = await unitOfWork.Users.GetAsync(u => u.Login == dto.Login &&
                u.Password == dto.Password && u.DeletedBy == null);

            if (user is null)
                throw new Exception();

            User mappedUser = mapper.Map<User>(dto);

            mappedUser.CreatedAt = DateTime.UtcNow;

            mappedUser = await unitOfWork.Users.AddAsync(mappedUser);

            await unitOfWork.SaveChangesAsync();

            return mappedUser;
        }

        public async Task<bool> DeleteAsync(Expression<Func<User, bool>> expression)
        {
            var user = await unitOfWork.Users.GetAsync(expression);

            if (user is null)
                throw new Exception();

            if (user.DeletedBy is not null)
                throw new Exception();

            await unitOfWork.Users.DeleteAsync(expression);
            await unitOfWork.SaveChangesAsync();

            return true;
        }

        public async Task<IEnumerable<User>> GetAllAsync(Expression<Func<User, bool>> expression = null)
        {
            return unitOfWork.Users.GetAll(expression);
        }

        public async Task<User> GetAsync(Expression<Func<User, bool>> expression)
        {
            return await unitOfWork.Users.GetAsync(expression);
        }

        public async Task<User> UpdateAsync(long id, UserForCreation dto)
        {
            var user = await unitOfWork.Users.GetAsync(u => u.Id == id && u.DeletedBy == null);

            if (user is null)
                throw new Exception();

            var mappedUser = mapper.Map(dto, user);

            mappedUser.UpdatedAt = DateTime.UtcNow;

            mappedUser = await unitOfWork.Users.UpdateAsync(mappedUser);

            await unitOfWork.SaveChangesAsync();

            return mappedUser;
        }
    }
}
