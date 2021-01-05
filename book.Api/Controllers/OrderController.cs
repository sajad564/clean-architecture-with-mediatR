using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using book.Application.common;
using book.Application.common.HelperClasses;
using book.Application.common.Resources;
using book.Application.CQRS.Command;
using book.Application.CQRS.Queries;
using book.Domain.Entities;
using book.Domain.Entities.pagination;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace book.Api.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    [Authorize]
    public class OrderController : ControllerBase
    {
        private readonly IMediator mediator;
        public OrderController(IMediator mediator)
        {
            this.mediator = mediator;

        }
        [HttpPost]
        public async Task<Response<bool>> AddOrder([FromBody] string ProductId)
        {
            return await mediator.Send(new AddOrderCommand(ProductId)) ; 
        }
        [HttpGet("{orderId}")]
        public async Task<Response<OrderResource>> GetOrder( string orderId) {
            return await mediator.Send(new GetOrderQuery(orderId)) ; 
        }
        [Authorize]
        [HttpGet("[Action]")]
        public async Task<Response<List<OrderResource>>> Current([FromQuery] GetCurrentUserOrdersQuery query) {
            var pagedOrder =  await mediator.Send(query) ;
            Response.AddPaginationToHeader(new Pagination(pagedOrder.Item.PageNumber ,pagedOrder.Item.PageSize,pagedOrder.Item.TotalPages , pagedOrder.Item.TotalCount)) ;
            return book.Application.common.Response.Ok<List<OrderResource>>(pagedOrder.Item.ToList()) ;
        }
        [HttpGet("[Action]")]
        [Authorize(Roles="admin")]
        public async Task<Response<List<OrderResource>>> GetOrders([FromQuery] GetOrdersQuery query ) {
            var pagedOrder =  await mediator.Send(query) ;
            Response.AddPaginationToHeader(new Pagination(pagedOrder.Item.PageNumber ,pagedOrder.Item.PageSize,pagedOrder.Item.TotalPages , pagedOrder.Item.TotalCount)) ;
            return book.Application.common.Response.Ok<List<OrderResource>>(pagedOrder.Item.ToList()) ; 
        }
        [HttpDelete("{Id}")]
        [Authorize]
        public async Task<Response<bool>> RemoveOrder(string Id) {
            return await mediator.Send(new RemoveOrderCommand(Id)) ; 
        }   
    }
}