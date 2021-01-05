using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using book.Domain.Common;
using book.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace book.Infrastructure.Data.Data.common
{
     public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        private DbSet<T> table {get;set;}
        protected MyDbContext db {get;set;}
        public BaseRepository(MyDbContext Db)
        {
            db = Db ;
            table = Db.Set<T>() ; 
        }
       

        public IQueryable<T> GetAll()
        {
            return  table ; 
        }
        public async Task AddAsync(T item)
        {
            await table.AddAsync(item) ; 
            await db.SaveChangesAsync() ; 
        }

        public async Task Remove(T item)
        {
            table.Remove(item)  ;
            await db.SaveChangesAsync() ; 
        }

        

        public  IQueryable<T> FindByExpression(Expression<Func<T, bool>> predicate)
        {
            return  table.Where(predicate).AsQueryable() ;
        }
        
        

        public async Task UpdateAsync(T item)
        {
            table.Update(item) ; 
            await db.SaveChangesAsync() ; 
        }
    }
}