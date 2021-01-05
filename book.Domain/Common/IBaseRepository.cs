using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace book.Domain.Common
{
    public interface IBaseRepository<T> where T : class
    {
         IQueryable<T> GetAll() ;
         Task AddAsync(T item) ; 
         Task Remove(T item) ;
         Task UpdateAsync(T item) ; 
         IQueryable<T> FindByExpression(Expression<Func<T,bool>> predicate) ; 
    }
}