using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace book.Domain.Entities.pagination
{
    public class PagedList<T> : List<T> 
    {
        public int PageNumber {get;set;}
        public int PageSize {get;set;}
        public int TotalPages {get;set;}
        public int TotalCount {get;set;}
        public PagedList(List<T> items , int pageNumber , int pageSize , int totalCount  )
        {
            PageNumber = pageNumber ;
            PageSize = pageSize ;
            TotalCount = totalCount  ;
            TotalPages =(int) Math.Ceiling(totalCount/(double)pageSize) ; 
            AddRange(items) ; 
        }
        public static async Task<PagedList<T>> ToPagedList(IQueryable<T> source , int pageNumber , int pageSize) {
            var count = source.Count() ;
            var  items = await source.Skip((pageNumber -1)*pageSize).Take(pageSize).ToListAsync() ;
            return new PagedList<T>(items , pageNumber , pageSize,count) ; 
        }
    }
}