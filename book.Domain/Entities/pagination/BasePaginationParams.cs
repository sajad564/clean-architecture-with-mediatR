using book.Domain.Common;

namespace book.Domain.Entities.pagination
{

    public class BasePaginationParams : DateTimeParams
    {
        private int _PageSize {get;set;} = 5 ;
        private int _pageNumber {get;set;} =1 ;
        public int Pagenumber {
            get {
                return _pageNumber ;
            }
            set {
                if(value>0) {
                    _pageNumber = value ; 
                }
            }
        }
        public int Pagesize  {
            get {
                return _PageSize ;
            }
            set {
                _PageSize = (value>10 || value<=0)? _PageSize : value ; 
            }
        }
        
    }
}