using System;
using book.Domain.Common;
using book.Domain.Enums;

namespace book.Domain.Entities
{
    public class Order : BaseEntity
    {
        public string UserId {get;set;}
        public User User {get;set;}
        public string ProductId {get;set;}
        public Book Product {get;set;}
        public DateTime CreatedDate {get;set;}
        public OrderStatusEnum status {get;set;}
        public Order()
        {
            CreatedDate = DateTime.UtcNow ; 
        }
    }
}