using book.Domain.Entities.pagination;
using Microsoft.AspNetCore.Http;

namespace book.Application.common.HeaderConvertors
{
    public static class MainConvertor
    {
        
        public static T Convert<T>(this T item ,HttpContext context )
        {
            //first get the basic pagination informations
            if(item is BasePaginationParams _base)
            _base.ConvertToBasePagination(context) ;

            if(item is BookPaginationParams _bparams)
            {
                _bparams.ConvertToBookPagination(context) ; 
                return item ; 
            } 
            if(item is CommentPaginationParams _cparams)
            {
                _cparams.ConvertToCommentPagination(context) ; 
                return item ; 
            } 
            if(item is OrderPaginationParams _oparams)
            {
                _oparams.ConvertToBasePagination(context) ; 
                return item ; 
            }
            return item ;   
        }
    }
}