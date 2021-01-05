using System;
using book.Domain.Enums;

namespace book.Domain.Entities.pagination
{
    public class OrderPaginationParams : BasePaginationParams
    {
       
        public BookCategoryEnum? Category{get;set;}
        public OrderStatusEnum? Status {get;set;} = null ; 
        public string UserId {get;set;}
        public string ProductId {get;set;}
    }
}