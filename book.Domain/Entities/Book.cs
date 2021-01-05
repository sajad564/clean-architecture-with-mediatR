using System;
using System.Collections.Generic;
using book.Domain.Common;
using book.Domain.Enums;

namespace book.Domain.Entities
{
    public class Book : BaseEntity
    {
        public string BookName {get;set;}
        public DateTime publishDate {get;set;}
        public string Description {get;set;}
        public decimal Price {get;set;}
        public List<Comment> Comments {get;set;}
        public BookCategoryEnum Category {get;set;}
        public List<Img> Imgs {get;set;}
        public List<Order> Orders {get;set;}
        public File File {get;set;}
        public User Author {get;set;}
        public string AuthorId {get;set;}
        public Book()
        {
            Comments = new List<Comment>() ; 
            Orders = new List<Order>() ; 
            Imgs = new List<Img>() ; 
        }
    }
}