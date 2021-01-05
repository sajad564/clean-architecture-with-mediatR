using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Reflection;

using System.Threading.Tasks;
using book.Application.common;
using book.Application.common.Resources;
using book.Application.CQRS.Queries;
using book.Domain.Entities.pagination;
using book.Domain.Enums;
using book.Test.Common;
using book.Test.Tests.BookController.Test.Data;
using FluentAssertions;
using Newtonsoft.Json;
using Xunit;

namespace book.Test.Tests.BookController.Test
{
    public class Book_Test : ClientProvider
    { 
        [Theory]
        [ClassData(typeof(AddBookData))]
       public async Task AddNewBook_ReturnResponseBool(MultipartFormDataContent formData)
        {
            //tested..works fine
            await AuthenticateMeBabyAsync() ;
            var response = await Client.PostAsync("api/book" , formData) ; 
            var result = await response.Content.ReadAsAsync<Response<bool>>();
            result.Item.Should().Be(true) ;
        }
        [Theory]
        [InlineData("3ef6116d-f03a-4241-857a-b2ea53a24a98")]
        public async Task GetBook_ReturnResponseBookResource(string bookId)
        {
            //tested..works fine
            var response = await Client.GetAsync($"/api/book/{bookId}") ; 
            var content = await response.Content.ReadAsAsync<Response<BookResource>>() ; 
            content.Item.Imgs.Count().Should().Be(1) ; 
        }
        [Theory]
        [ClassData(typeof(FilterBook))]
        public async Task GetBookPerPageWithFilter_ShouldReturnPagedListBookResources(GetBooksPerPageQuery query)
        {
            //tested..works fine
            await AuthenticateMeBabyAsync() ;
            var request = GetRequestCreator(query) ; 
            var response = await Client.SendAsync(request) ; 
            var content = await response.Content.ReadAsAsync<Response<List<BookResource>>>() ; 
            content.Item.Count().Should().NotBe(0) ;
        }
        [Theory]
        [InlineData("14195a11-ea80-46b4-841c-8aebf2656deb")]
        public async Task RemoveBook_ReturnResponseBool(string bookId)
        {
            //tested..works fine
            await AuthenticateMeBabyAsync() ; 
            var request = RemoveRequestCreator(bookId)  ;
            var response = await Client.SendAsync(request) ; 
            var content = await response.Content.ReadAsAsync<Response<bool>>() ;
            content.Item.Should().Be(true) ; 
        }
        private HttpRequestMessage GetRequestCreator(GetBooksPerPageQuery query)
        {
            var request = new HttpRequestMessage( HttpMethod.Get,"/api/book")   ;
            foreach(PropertyInfo info in query.GetType().GetProperties())
            {
                if(info.Name=="BookCategories")
                {
                    var list = info.GetValue(query) as List<BookCategoryEnum> ; 
                    var intList  =  list.Select( item => Convert.ToInt32(item).ToString()) ; 
                    request.Headers.Add(info.Name , intList) ; 
                }
                else
                {
                    request.Headers.Add(info.Name , info.GetValue(query)?.ToString()) ; 
                }
            }
            // Client.DefaultRequestHeaders.Add("minPrice" , ) ; 
            return request ; 
        }
        private HttpRequestMessage RemoveRequestCreator(string bookId)
        {
            return new HttpRequestMessage(HttpMethod.Delete , $"api/book/{bookId}") ; 
        }
    }
}