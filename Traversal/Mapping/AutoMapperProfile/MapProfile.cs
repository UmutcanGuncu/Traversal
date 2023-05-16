using AutoMapper;
using DTOLayer.DTOs.AnnouncementDTOs;
using DTOLayer.DTOs.AppUserDTOs;
using EntityLayer.Concrete;

namespace Traversal.Mapping.AutoMapperProfile
{
    public class MapProfile : Profile
    {
        public MapProfile()
        {
            CreateMap<AnnouncementAddDTO, Announcement>();
            CreateMap<Announcement,AnnouncementAddDTO>();

            CreateMap<AnnouncementListDTO, Announcement>();
            CreateMap<Announcement,AnnouncementListDTO>();

            CreateMap<AnnouncementUpdateDTO, Announcement>();
            CreateMap<Announcement,AnnouncementUpdateDTO>();
            
            CreateMap<UserRegisterrDTO,AppUser>();
            CreateMap<AppUser,UserRegisterrDTO>();

            CreateMap<UserLoginDTO,AppUser>();
            CreateMap<AppUser,UserLoginDTO>();


        }
    }
}
