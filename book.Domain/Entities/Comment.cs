using System;
using book.Domain.Common;

namespace book.Domain.Entities
{
    public class Comment : BaseEntity
    {
        public string Description {get;set;}
        public string senderId {get;set;}
        public User Sender {get;set;}
        public string BookId {get;set;}
        public Book Book {get;set;}
        public DateTime CreatedDate {get;set;}
    }
}