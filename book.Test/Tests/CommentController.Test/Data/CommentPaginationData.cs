using System;
using book.Application.CQRS.Queries;
using Xunit;

namespace book.Test.Tests.CommentController.Test.Data
{
    public class CommentPaginationData : TheoryData<GetCommentsQuery>
    {
        public CommentPaginationData()
        {
            for(int i=0 ; i<=5; i++)
            {
                Add(MakeCommentsQuery()) ; 
            }
        }
        private GetCommentsQuery MakeCommentsQuery()
        {
            var rand = new Random() ; 
            var query = new GetCommentsQuery
            {
                Pagesize = rand.Next(5)  , 
                Pagenumber = rand.Next(3) ,
                BookId = "083c9930-3327-4d28-86fa-b4c830c7e188" ,
                MinDateTime = DateTime.UtcNow.AddYears(-1) ,
                MaxDateTime = DateTime.UtcNow
            };
            return query ;
        }
    }
}