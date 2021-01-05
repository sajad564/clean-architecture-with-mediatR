using System;
using System.Linq;
using System.Security.Claims;
using book.Domain.Entities.pagination;
using book.Domain.Enums;
using Microsoft.AspNetCore.Http;

namespace book.Application.common.HeaderConvertors
{
    public static class GetFromHeader
    {
        public static BasePaginationParams ConvertToBasePagination(this BasePaginationParams _params , HttpContext context)
        {
            _params.Pagenumber = int.Parse(context.Request.Headers["PageNumber"]) ;
                _params.Pagesize = int.Parse(context.Request.Headers["PageSize"])  ;
                _params.MinDateTime = DateTime.Parse(context.Request.Headers["minDateTime"])  ;
                _params.MaxDateTime = DateTime.Parse(context.Request.Headers["maxDateTime"])  ;
            return _params ; 
        }
        public static BookPaginationParams ConvertToBookPagination( this BookPaginationParams _params , HttpContext context)
        {
                _params.Pagenumber = int.Parse(context.Request.Headers["PageNumber"]) ;
                _params.Pagesize = int.Parse(context.Request.Headers["PageSize"])  ;
                _params.MinDateTime = DateTime.Parse(context.Request.Headers["minDateTime"])  ;
                _params.MaxDateTime = DateTime.Parse(context.Request.Headers["maxDateTime"])  ;
                _params.BookCategories = context.Request.Headers["BookCategories"].Select(item => (BookCategoryEnum)int.Parse(item)).ToList(); 
                _params.maxPrice = int.Parse(context.Request.Headers["maxPrice"])  ;
                _params.minPrice = int.Parse(context.Request.Headers["minPrice"])  ;
                return _params ; 
        }
        public static CommentPaginationParams ConvertToCommentPagination(this CommentPaginationParams _params , HttpContext context)
        {
            _params.UserId = context.User.FindFirst(ClaimTypes.NameIdentifier).Value ;
            _params.BookId = context.Request.Headers["BookId"] ; 
            return _params ; 
        }
        public static OrderPaginationParams ConvertToOrderPagination(this OrderPaginationParams _params , HttpContext context)
        {
            _params.UserId = context.Request.Headers["UserId"] ; 
            _params.ProductId = context.Request.Headers["ProductId"] ; 
            _params.Status  = context.Request.Headers["Status"].Select(item => (OrderStatusEnum)int.Parse(item)).FirstOrDefault() ;
            _params.Category = context.Request.Headers["Category"].Select(item =>(BookCategoryEnum)int.Parse(item)).FirstOrDefault() ; 
            return _params ; 
        }
    }
}