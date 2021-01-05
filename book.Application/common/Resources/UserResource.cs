using System.Collections.Generic;

namespace book.Application.common.Resources
{
    public class UserResource
    {
        public string Id {get;set;}
        public string Username {get;set;}
        public string Email {get;set;}
        public PhotoResource Photo {get;set;}
    }
}