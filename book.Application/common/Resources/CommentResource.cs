using System;

namespace book.Application.common.Resources
{
    public class CommentResource
    {
        public string Id {get;set;}
        public DateTime Createddate {get;set;}
        public UserResource Sender {get;set;}
        public BookResource Book {get;set;}
    }
}