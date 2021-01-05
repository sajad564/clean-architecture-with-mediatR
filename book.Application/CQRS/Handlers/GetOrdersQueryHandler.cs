using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using book.Application.common;
using book.Application.common.HelperClasses;
using book.Application.common.Resources;
using book.Application.CQRS.Queries;
using book.Domain.Entities.pagination;
using book.Domain.Interfaces.Repositories;
using MediatR;

namespace book.Application.CQRS.Handlers
{
    public class GetOrdersQueryHandler : IRequestHandler<GetOrdersQuery, Response<PagedList<OrderResource>>>
    {
        private readonly IOrderRepository orderRepo;
        private readonly PagedListConvertor pagedConvertor;
        public GetOrdersQueryHandler(IOrderRepository orderRepo, PagedListConvertor pagedConvertor)
        {
            this.pagedConvertor = pagedConvertor;
            this.orderRepo = orderRepo;

        }
        public async Task<Response<PagedList<OrderResource>>> Handle(GetOrdersQuery request, CancellationToken cancellationToken)
        {
            var orders = await orderRepo.GetOrderPerPageAsync(request);
            if (orders.Any())
            {
                var orderResources = pagedConvertor.orderPagedToResource(orders) ; 
                return Response.Ok<PagedList<OrderResource>>(orderResources );
            }
            return Response.Fail<PagedList<OrderResource>>("سفارشی با این مشخصات یافت نشد" , StatusCodeEnum.NOTFUOUND) ; 
        }
    }
}