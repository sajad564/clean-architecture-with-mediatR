using book.Application.common;
using book.Application.common.Resources;
using book.Domain.Entities;
using MediatR;

namespace book.Application.CQRS.Queries
{
    public class GetOrderQuery : BaseInformation , IRequest<Response<OrderResource>>
    {
        public string OrderId {get;set;}
        public GetOrderQuery(string OrderId)
        {
            this.OrderId = OrderId ; 
        }
    }
}