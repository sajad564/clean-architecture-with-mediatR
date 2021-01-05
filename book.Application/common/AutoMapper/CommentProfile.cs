using AutoMapper;
using book.Application.common.Resources;
using book.Domain.Entities;

namespace book.Application.common.AutoMapper
{
    public class CommentProfile : Profile
    {
        public CommentProfile()
        {
            CreateMap<Comment , CommentResource>() ; 
        }
    }
}