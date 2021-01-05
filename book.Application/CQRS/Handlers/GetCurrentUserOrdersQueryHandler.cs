using System.Threading;
using book.Application.common;
using book.Domain.Entities;
using MediatR;
using System.Threading.Tasks;
using book.Domain.Interfaces.Repositories;
using book.Application.CQRS.Queries;
using book.Domain.Entities.pagination;
using System.Linq;
using book.Application.common.Resources;
using book.Application.common.HelperClasses;

namespace book.Application.CQRS.Handlers
{
    public class GetCurrentUserOrdersQueryHandler : IRequestHandler<GetCurrentUserOrdersQuery, Response<PagedList<OrderResource>>>
    {
        private readonly IOrderRepository orderRepo;
        private readonly PagedListConvertor pagedConvertor;
        public GetCurrentUserOrdersQueryHandler(IOrderRepository orderRepo, PagedListConvertor pagedConvertor)
        {
            this.pagedConvertor = pagedConvertor;
            this.orderRepo = orderRepo;

        }

        public async Task<Response<PagedList<OrderResource>>> Handle(GetCurrentUserOrdersQuery request, CancellationToken cancellationToken)
        {
            PagedList<Order> pagedOrder = await orderRepo.GetOrderPerPageAsync(request as OrderPaginationParams);
            if (pagedOrder.Any())
            {
                PagedList<OrderResource> poagedOrderResource = pagedConvertor.orderPagedToResource(pagedOrder) ; 
                return Response.Ok<PagedList<OrderResource>>(poagedOrderResource);
            }
            return Response.Fail<PagedList<OrderResource>>("سفارشی یافت نشد", StatusCodeEnum.NOTFUOUND);
        }
    }
}