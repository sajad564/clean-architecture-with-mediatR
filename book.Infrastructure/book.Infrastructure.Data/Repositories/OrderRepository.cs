using System;
using System.Linq;
using System.Threading.Tasks;
using book.Domain.Entities;
using book.Domain.Entities.pagination;
using book.Domain.Interfaces.Repositories;
using book.Infrastructure.Data.Data;
using book.Infrastructure.Data.Data.common;
using Microsoft.EntityFrameworkCore;

namespace book.Infrastructure.Data.Repositories
{
    public class OrderRepository : BaseRepository<Order> , IOrderRepository 
    {
       public OrderRepository(MyDbContext db) : base(db)
       {
           
       }

        public async Task<Order> GetOrderAsync(string Id)
        {
            return await FindByExpression(o => o.Id==Id ).Include(o => o.User).Include(o => o.Product).FirstOrDefaultAsync() ; 
        }

        public  async Task<PagedList<Order>> GetOrderPerPageAsync(OrderPaginationParams pageParams)
        {
            var filteredSource = Filter(pageParams).Include(o => o.User).Include(o => o.Product)  ; 
            return  await PagedList<Order>.ToPagedList(filteredSource , pageParams.Pagenumber,pageParams.Pagesize) ;
        }
        private IQueryable<Order> Filter(OrderPaginationParams pageParams) 
        {
            return FindByExpression(item => 
            ((pageParams.MinDateTime==null) || item.CreatedDate >= pageParams.MinDateTime )
            && ((pageParams.MaxDateTime==null) || item.CreatedDate <= pageParams.MaxDateTime) 
            && ( pageParams.Category==null || item.Product.Category==pageParams.Category)
            && (pageParams.Status==null || item.status==pageParams.Status)
            && ((string.IsNullOrEmpty(pageParams.UserId )|| item.UserId==pageParams.UserId )) );
        } 
    }
}