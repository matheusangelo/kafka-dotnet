using App.Domain.Entities;
using AutoMapper;
namespace App.Application.Mappers
{
    public class MapperConfig : Profile
    {
        public MapperConfig()
        {
            CreateMap<CreateMessageDTO, Message>();
        }
    }
}