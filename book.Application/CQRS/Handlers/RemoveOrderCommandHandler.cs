using System.Linq;
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
    public class RemoveOrderCommandHandler : IRequestHandler<RemoveOrderCommand, Response<bool>>
    {
        private readonly IOrderRepository orderRepo;
        public RemoveOrderCommandHandler(IOrderRepository orderRepo)
        {
            this.orderRepo = orderRepo;


        }
        public async Task<Response<bool>> Handle(RemoveOrderCommand request, CancellationToken cancellationToken)
        {
            if(AuthorizeRemoveOrder(request))
            {
                Order order = await orderRepo.GetOrderAsync(request.OrderId);
                await orderRepo.Remove(order) ; 
                return Response.Ok();
            }
            

            return Response.Fail<bool>("شما مجاز به انجام این کار نیسصتید"   , StatusCodeEnum.NOTAUTHORIZE ) ; 
        }
        private bool AuthorizeRemoveOrder(RemoveOrderCommand context)
        {
            var IsAdmin = context.Roles.Where(role => role=="admin").Any() ;
            var OrderBelongToUser = orderRepo.FindByExpression(o => o.Id==context.OrderId && o.UserId==context.Userid).Any() ;
            // user not bought product , it just added
            var orderIsInAddedStage = orderRepo.FindByExpression(o => o.Id==context.OrderId && o.status==OrderStatusEnum.ADDED).Any() ;
            return (OrderBelongToUser && orderIsInAddedStage) || (IsAdmin && orderIsInAddedStage) ; 
        }
    }
}