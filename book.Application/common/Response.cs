using System.Collections.Generic;
using System.Linq;

namespace book.Application.common
{
    public static class Response
    {
        public static Response<T> Fail<T>(IDictionary<string,string[]> Errors , StatusCodeEnum StatusCode , T item = default) {
            return new Response<T>(item,Errors,StatusCode ) ; 
        }
        public static Response<T> Fail<T>(string Error , StatusCodeEnum StatusCode , T item = default) {
            IDictionary<string , string[]> errorDictionary = new Dictionary<string, string[]>() ; 
            errorDictionary.Add("globalError" , new string[] {Error}) ; 
            return new Response<T>(item,errorDictionary,StatusCode ) ; 
        }
        public static Response<T> Ok<T>(T item ) {
            
            return new Response<T>(item,null,StatusCodeEnum.OK) ; 
        }
        public static Response<bool> Ok()
        {
            return new Response<bool>( true, null , StatusCodeEnum.OK ) ; 
        }
         
    }
   
    public class Response<T>  {
        public Response(T item , IDictionary<string,string[]> errors , StatusCodeEnum status )
        {
            Item = item  ;
            Errors = errors ; 
            Status = status ;
        }
        public T Item {get;set;}
        public IDictionary<string,string[]> Errors {get;set;}
        public StatusCodeEnum Status {get;set;}
    }
}