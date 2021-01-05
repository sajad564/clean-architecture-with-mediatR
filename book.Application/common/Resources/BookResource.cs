using System.Collections.Generic;
using book.Domain.Enums;

namespace book.Application.common.Resources
{
    public class BookResource
    {
        public string Id {get;set;}
        public string Bookname {get;set;}
        public string Description {get;set;}
        public decimal Price {get;set;}
        public BookCategoryEnum Category {get;set;}
        public UserResource Author {get;set;}
        public List<PhotoResource> Imgs {get;set;}
        public BookResource() {
            Imgs = new List<PhotoResource>()  ;
            
        }
    }
}