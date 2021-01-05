using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using book.Application.common;
using book.Application.common.Resources;
using book.Application.CQRS.Queries;
using book.Domain.Entities;
using book.Domain.Interfaces.Repositories;
using MediatR;

namespace book.Application.CQRS.Handlers
{
    public class GetOrderQueryHandler : IRequestHandler<GetOrderQuery, Response<OrderResource>>
    {
        private readonly IOrderRepository orderRepo;
        private readonly IMapper mapper;
        public GetOrderQueryHandler(IOrderRepository orderRepo, IMapper mapper)
        {
            this.mapper = mapper;
            this.orderRepo = orderRepo;

        }
        public async Task<Response<OrderResource>> Handle(GetOrderQuery request, CancellationToken cancellationToken)
        {
            if(AuthorizeToGetOrder(request))
            {
                var order = await orderRepo.GetOrderAsync(request.OrderId);
                return Response.Ok<OrderResource>(mapper.Map<OrderResource>(order)) ; 
            }
            return Response.Fail<OrderResource>("شما مجاز به انجام این کار نیستید",  StatusCodeEnum.NOTAUTHORIZE) ; 
            
        }
        private bool AuthorizeToGetOrder(GetOrderQuery context)
        {
            var IsAdmin = context.Roles.Where(role => role=="admin").Any() ; 
            var orderBelongToUser = orderRepo.FindByExpression(o => o.UserId==context.Userid && o.Id==context.OrderId).Any() ;
            return IsAdmin || orderBelongToUser ; 
        }
    }
}