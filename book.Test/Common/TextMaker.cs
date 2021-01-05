using System.Linq ; 
namespace book.Test.Common
{
    public  class TextMaker
    {
        public static string QueryStringCreator<T>(T item , string Route)
        {
            var queryString = Route ; 
            item.GetType().GetProperties()
            .Where(prop => prop.GetValue(item)!=null)
            .Select(prop => queryString+=$"{prop.Name}={prop.GetValue(item)}&&")
            .ToList() ;
            return queryString.Substring(0 , queryString.Length-2) ;
        }
    }
}