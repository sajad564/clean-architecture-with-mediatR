using System;
using System.Collections.Generic;
using System.Linq;
using book.Application.CQRS.Queries;
using book.Domain.Enums;
using Xunit;

namespace book.Test.Tests.BookController.Test.Data
{
    public class FilterBook : TheoryData<GetBooksPerPageQuery>
    {
        // how many getbookperpage instance u want ?
        // 'counter' take care of that
        public FilterBook()
        {
            CreateQuery(3) ; 
        }
        private void CreateQuery(int counter)
        {
            
            for(int i =1 ;i<=counter;i++)
            {
                var query = new GetBooksPerPageQuery {
                BookCategories = GetCategory(i) , //  
                MinDateTime = DateTime.Today.AddYears(-i) ,
                MaxDateTime = DateTime.Today.AddYears(i) ,
                minPrice = 0 ,
                maxPrice = 2 , // CreateRandomPriceFromOneToTen() ,
                Pagenumber = 2
                        } ;
                Add(query) ; 
            } 
        }
        private List<BookCategoryEnum> GetCategory(int numberOfCategory)
        {
            if(numberOfCategory==1)
            {
                return new List<BookCategoryEnum> {BookCategoryEnum.Science} ; 
            }
            if(numberOfCategory==2)
            {
                return new List<BookCategoryEnum> {BookCategoryEnum.Computer , BookCategoryEnum.Science} ; 
            }
            else 
            {
                return Enum.GetValues(typeof(BookCategoryEnum)).Cast<BookCategoryEnum>().ToList() ; 
            }
        }
        private  decimal CreateRandomPriceFromOneToTen()
        {
            var rand = new Random() ;
            decimal decnumber = rand.Next(10) ; 
            return decnumber ; 
        }
    }
}