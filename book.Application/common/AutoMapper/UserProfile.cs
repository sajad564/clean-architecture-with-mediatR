using AutoMapper;
using book.Application.common.Resources;
using book.Domain.Entities;

namespace book.Application.common.AutoMapper
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<User , UserResource>().ForMember(
                u => u.Photo  ,
                find => find.MapFrom(ur => ur.Img)
            ) ; 
        }
    }
}