using AutoMapper;
using ServerApp.DTO;
using ServerApp.Models;

namespace ServerApp.Helpers
{
    public class MapperProfiles: Profile
    {
        public MapperProfiles()
        {
            CreateMap<User,UserForListDTO>();
            CreateMap<User,UserForDetailsDTO>();
        }
    }
}