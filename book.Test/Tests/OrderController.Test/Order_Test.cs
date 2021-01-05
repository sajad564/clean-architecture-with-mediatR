using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using book.Application.common;
using book.Application.common.Resources;
using book.Application.CQRS.Queries;
using book.Domain.Entities.pagination;
using book.Test.Common;
using book.Test.Tests.OrderController.Test.Data;
using FluentAssertions;
using Newtonsoft.Json;
using Xunit;

namespace book.Test.Tests.OrderController.Test
{
    public class Order_Test : ClientProvider
    {
        
        [Theory]
        [InlineData("083c9930-3327-4d28-86fa-b4c830c7e188")]
        [InlineData("1241c24c-3e8b-466c-9913-53d69206a0b3")]
        [InlineData("5f2cd492-da78-4288-8fe4-8d19ffb61550")]
        public async Task AddOrder_ResponseBool(string ProductId)
        {
            // tested .. works fine
            await AuthenticateMeBabyAsync() ; 
            var response = await Client.PostAsJsonAsync("api/order" ,ProductId ) ; 
            var content = await  response.Content.ReadAsAsync<Response<bool>>();
            content.Item.Should().Be(true) ;
        }
        [Theory]
        [ClassData(typeof(CurrentUserOrderData))]
        public async Task CurrentUserOrders_ReturnPagedList(GetCurrentUserOrdersQuery query)
        {
            //tested..works fine
            await AuthenticateMeBabyAsync() ;
            
            var queryString =TextMaker.QueryStringCreator<GetCurrentUserOrdersQuery>(query , "/api/order/current?") ; 
            var response = await Client.GetAsync(queryString) ;
            var content = await response.Content.ReadAsAsync<Response<List<OrderResource>>>() ;
            content.Item.Count().Should().NotBe(0);
        }
        [Theory]
        [InlineData("75b944a7-b39b-4009-91b2-a20f5713ad48")]
        public async Task GetOrderById_returnResponseOrderResource(string orderId)
        {
            //tested..works fine
            await AuthenticateMeBabyAsync() ; 
            var response = await Client.GetAsync($"/api/order/{orderId}") ; 
            var content = await response.Content.ReadAsAsync<Response<OrderResource>>() ;
            content.Status.Should().Be(StatusCodeEnum.OK) ; 
        }
        [Theory]
        [InlineData("809cb4a3-7fc9-4248-adef-ad6e74ac2334")]
        public async Task RemoveOrder_ReturnResponseBool(string orderId)
        {
            // tested.. works fine
            await AuthenticateMeBabyAsync() ; 
            var response = await Client.SendAsync(DeleteRequestCreator(orderId)) ; 
            var content = await response.Content.ReadAsAsync<Response<bool>>() ; 
            content.Item.Should().Be(true); 
        }
        private HttpRequestMessage DeleteRequestCreator(string orderId)
        {
            var req = new HttpRequestMessage(HttpMethod.Delete , $"/api/order/{orderId}") ; 
            return req ;
        }
       
         
    }
}