using System;
using System.Collections.Generic;
using book.Application.CQRS.Queries;
using book.Domain.Enums;
using Xunit;

namespace book.Test.Tests.OrderController.Test.Data
{
    public class CurrentUserOrderData : TheoryData<GetCurrentUserOrdersQuery>
    {
        
        public CurrentUserOrderData()
        {
            foreach(var query in Data())
            {
                Add(query) ; 
            }
        }
        private List<GetCurrentUserOrdersQuery> Data()
        {
            List<GetCurrentUserOrdersQuery> queries = new List<GetCurrentUserOrdersQuery>
            {
                new GetCurrentUserOrdersQuery { Status =OrderStatusEnum.ADDED , MaxDateTime = DateTime.Now} ,
                new GetCurrentUserOrdersQuery {Category = BookCategoryEnum.Computer , ProductId = "5f2cd492-da78-4288-8fe4-8d19ffb61550" , Status =OrderStatusEnum.ADDED} ,
                new GetCurrentUserOrdersQuery {Category = BookCategoryEnum.Computer , ProductId = "5f2cd492-da78-4288-8fe4-8d19ffb61550" , Status =OrderStatusEnum.ADDED}
            };
            return queries ; 
        }
    }
}