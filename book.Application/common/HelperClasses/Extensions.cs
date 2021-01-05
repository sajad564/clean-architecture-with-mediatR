using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace book.Application.common.HelperClasses
{
    public static class Extensions
    {
        public static void AddPaginationToHeader( this HttpResponse response, Pagination pagination) 
        {
            response.Headers.Add("Access-controll-expose-headers" , "pagination") ; 
            response.Headers.Add("pagination" , JsonConvert.SerializeObject(pagination)) ;
        }
    }
}