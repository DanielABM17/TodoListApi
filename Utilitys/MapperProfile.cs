using AutoMapper;
using DTO;
using Models;

namespace Utilitys
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<Item, CreateTaskDto>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.Initial, opt => opt.MapFrom(src => src.Initial.ToString("dd/MM/yyyy")));

            CreateMap<CreateTaskDto, Item>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.Initial, opt => opt.MapFrom(src => Convert.ToDateTime(src.Initial)));
                
            CreateMap<Item, ItemDto>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.Initial, opt => opt.MapFrom(src => src.Initial.ToString("dd/MM/yyyy")))
                .ForMember(dest => dest.IsCompleted, opt => opt.MapFrom(src => src.IsCompleted == true ? 1 : 0))
                .ForMember(dest => dest.Completed, opt => opt.MapFrom(src => src.Completed.ToString("dd/MM/yyyy")));


            CreateMap<ItemDto, Item>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.Initial, opt => opt.MapFrom(src => Convert.ToDateTime(src.Initial)))
                .ForMember(dest => dest.IsCompleted, opt => opt.MapFrom(src => src.IsCompleted == 1 ? true : false))
                .ForMember(dest => dest.Completed, opt => opt.MapFrom(src => Convert.ToDateTime(src.Completed)));


        }

    }
}
