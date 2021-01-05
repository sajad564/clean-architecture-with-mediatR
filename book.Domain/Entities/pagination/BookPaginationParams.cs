using System;
using System.Collections.Generic;
using System.Linq;
using book.Domain.Enums;

namespace book.Domain.Entities.pagination
{
    
    public class BookPaginationParams : BasePaginationParams
    {
        
        public decimal? minPrice {get;set;}
        
        public decimal? maxPrice {get;set;}
        
        // private List<BookCategoryEnum> bookCategories =  Enum.GetValues(typeof(BookCategoryEnum)).Cast<BookCategoryEnum>().ToList() ;
        // public List<BookCategoryEnum> BookCategories {
        //     get {
        //         return bookCategories ; 
        //     }
        //     set {
        //         // if(value.Any()) {
        //         //     bookCategories = null ; 
        //         //     foreach(BookCategoryEnum item in value) {
        //         //         bookCategories.Add(item) ; 
        //         //     }
        //         // }
        //         bookCategories= null ;
        //         bookCategories.AddRange((List<BookCategoryEnum>) value) ; 
        //     }
        // }
        public List<BookCategoryEnum> BookCategories { get;set; }
        public string AuthorId {get;set;} 
    }
}