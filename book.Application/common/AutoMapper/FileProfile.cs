using AutoMapper;
using book.Application.common.Resources;
using book.Domain.Entities;

namespace book.Application.common.AutoMapper
{
    public class FileProfile : Profile
    {
        public FileProfile()
        {
            CreateMap<File,FileResource>() ; 
        }
    }
}