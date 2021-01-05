using System.Collections.Generic;

namespace book.Domain.Entities
{
    public class EmailMessage
    {
        public string Subject {get;set;}
        public string Content {get;set;}
        public List<string> EmailAddresses {get;set;}
        public EmailMessage( IEnumerable<string> addresses, string subject,string content)
        {
            EmailAddresses = new List<string>() ;
            EmailAddresses.AddRange(addresses) ; 
            Subject = subject ;
            Content = content ;  
        }
    }
}