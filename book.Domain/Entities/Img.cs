using System;
using book.Domain.Common;

namespace book.Domain.Entities
{
    public class Img : BaseFile
    {
        
        public User User {get;set;}
        public Book Book {get;set;}
        public string UserId {get;set;}
        public string BookId {get;set;}
    }
}