using System;

namespace book.Domain.Entities.pagination
{
    public class CommentPaginationParams : BasePaginationParams
    {
        
        public string UserId {get;set;}
        public string BookId {get;set;}

    }
}