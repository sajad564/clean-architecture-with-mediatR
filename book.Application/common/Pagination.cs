namespace book.Application.common
{
    public class Pagination
    {
        public int Pagenumber {get;private set;}
        public int Pagesize {get;private set;}
        public int Totalpages {get;private set;}
        public int Totalcount {get; private set;}
        public Pagination(int pageNumber , int pageSize , int totalPages , int totalCount)
        {
            Pagenumber = pageNumber ;
            Totalpages = totalPages ;
            Pagesize = pageSize ; 
            Totalcount = totalCount ; 
        }
    }
}