using AutoMapper;
using Udemy.Domain.Entities;
using Udemy.Service.DTOs;

namespace Udemy.Service.Mappers
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<User, UserForCreation>().ReverseMap();
        }
    }
}
