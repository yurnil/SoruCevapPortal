using AutoMapper;
using SoruCevapPortal.API.DTOs;
using SoruCevapPortal.API.Models;

namespace SoruCevapPortal.API.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {

            CreateMap<RegisterDto, AppUser>();

        }
    }
}