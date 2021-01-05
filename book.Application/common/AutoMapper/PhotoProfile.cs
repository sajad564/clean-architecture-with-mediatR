using AutoMapper;
using book.Application.common.Resources;
using book.Domain.Entities;

namespace book.Application.common.AutoMapper
{
    public class PhotoProfile : Profile
    {
        public PhotoProfile()
        {
            CreateMap<Img,PhotoResource>() ; 
        }
    }
}