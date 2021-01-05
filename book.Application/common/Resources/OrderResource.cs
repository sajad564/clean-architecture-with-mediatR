using System;

namespace book.Application.common.Resources
{
    public class OrderResource
    {
        public string Id {get;set;}
        public DateTime CreatedDate {get;set;}
        public UserResource User {get;set;}
        public BookResource Book {get;set;}
    }
}