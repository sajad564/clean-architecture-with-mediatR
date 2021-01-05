using AutoMapper;
using book.Application.common.Resources;
using book.Domain.Entities;
namespace book.Application.common.AutoMapper
{
    public class BookProfile : Profile
    {
        public BookProfile()
        {
            CreateMap<Book,BookResource>() ; 
            
        }
    }
}