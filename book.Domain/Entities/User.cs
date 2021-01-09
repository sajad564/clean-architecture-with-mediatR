using System;
using System.Collections.Generic;
using book.Domain.Common;
using Microsoft.AspNetCore.Identity;

namespace book.Domain.Entities
{
    //  domain layer should not depend on any layer or framework
    // but is's happening here
    public class User : IdentityUser
    {
        public string FirstName {get;set;}
        public string LastName {get;set;}
        public Img Img {get;set;}
        public string ImgId {get;set;}
        public DateTime LastTimeSendConfirmLink {get;set;}
        public bool IsAlive {get;set;}
        public string RefreshToken {get;set;}
        public DateTime ExpiredRefreshTokenDate {get;set;}
        public List<Book> Books {get;set;}
        public List<Order> Orders {get;set;}
        public List<Comment> Comments {get;set;}
        public DateTime? LastTimeSendRecovryLink {get;set;}
        public User()
        {
            Comments = new List<Comment>() ; 
            Books = new List<Book>() ; 
        }
    }
}