using System;
using System.Threading;
using System.Threading.Tasks;
using book.Application.common;
using book.Application.CQRS.Command;
using book.Domain.Entities;
using book.Domain.Enums;
using book.Domain.Interfaces.Repositories;
using MediatR;

namespace book.Application.CQRS.Handlers
{
    public class AddOrderCommandHandler : IRequestHandler<AddOrderCommand, Response<bool>>
    {
        
        private readonly IOrderRepository orderRepo;
        public AddOrderCommandHandler( IOrderRepository orderRepo)
        {
            this.orderRepo = orderRepo;
        }
        public async Task<Response<bool>> Handle(AddOrderCommand request, CancellationToken cancellationToken)
        {
                var order = new Order
                {
                    ProductId = request.ProductId , 
                    UserId = request.Userid  , 
                    CreatedDate = DateTime.UtcNow  , 
                    status = OrderStatusEnum.ADDED 
                };
                await orderRepo.AddAsync(order) ; 
                return Response.Ok();
        }
    }
}