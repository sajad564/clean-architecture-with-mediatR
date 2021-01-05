using System.Collections.Generic;
using System.Linq;
using book.Application.common.AutoMapper;
using book.Application.common.Resources;
using book.Domain.Entities;
using book.Domain.Entities.pagination;

namespace book.Application.common.HelperClasses
{
    public class PagedListConvertor
    {
        
        public PagedListConvertor()
        {

        }
        public  PagedList<CommentResource> CommentPagedToResource(PagedList<Comment> commentPaged) {
             var dto = Mapping.Mapper.Map<List<CommentResource>>(commentPaged.ToList()) ;
            return  new PagedList<CommentResource>(dto , commentPaged.PageSize , commentPaged.PageSize , commentPaged.TotalCount) ; 
        }
        public  PagedList<BookResource> bookPagedToResource(PagedList<Book> bookPaged) {
            var dto = Mapping.Mapper.Map<List<BookResource>>(bookPaged.ToList()) ; 
            return  new PagedList<BookResource>(dto, bookPaged.PageSize , bookPaged.PageSize , bookPaged.TotalCount)  ; 
        }
        public  PagedList<OrderResource> orderPagedToResource(PagedList<Order> orderPaged) {
            var dto = Mapping.Mapper.Map<List<OrderResource>>(orderPaged.ToList()) ;
            return new PagedList<OrderResource>(dto, orderPaged.PageSize , orderPaged.PageSize , orderPaged.TotalCount) ; 
        }
        
       

    }
}