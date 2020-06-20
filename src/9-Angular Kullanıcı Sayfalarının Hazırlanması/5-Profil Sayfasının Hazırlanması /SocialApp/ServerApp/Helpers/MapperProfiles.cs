using System.Linq;
using AutoMapper;
using ServerApp.DTO;
using ServerApp.Models;

namespace ServerApp.Helpers
{
    public class MapperProfiles: Profile
    {
        public MapperProfiles()
        {
            CreateMap<User,UserForListDTO>()
                .ForMember(dest => dest.Image, opt => 
                    opt.MapFrom(src => src.Images.FirstOrDefault(i=>i.IsProfile))    )
                .ForMember(dest => dest.Age, opt => opt.MapFrom(src =>src.DateOfBirth.CalculateAge()));
            CreateMap<User,UserForDetailsDTO>()
                .ForMember(dest => dest.ProfileImageUrl, opt => 
                    opt.MapFrom(src => src.Images.FirstOrDefault(i=>i.IsProfile).Name))
                 .ForMember(dest => dest.Age, opt => opt.MapFrom(src =>src.DateOfBirth.CalculateAge()));    
            
            ;
            CreateMap<Image,ImagesForDetails>();
        }
    }
}