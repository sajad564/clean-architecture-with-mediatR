using System;
using System.Threading.Tasks;
using book.Domain.Common;
using book.Domain.Entities;
using book.Domain.Entities.pagination;

namespace book.Domain.Interfaces.Repositories
{
    public interface IOrderRepository : IBaseRepository<Order>
    {
        Task<Order> GetOrderAsync(string Id)  ; 
       Task<PagedList<Order>>  GetOrderPerPageAsync(OrderPaginationParams pageParams) ;
    }
}