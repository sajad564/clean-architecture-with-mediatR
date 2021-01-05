using System.Collections.Generic;
using System.Net.Http;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using book.Application.common;
using book.Application.common.Resources;
using book.Application.CQRS.Command;
using book.Application.CQRS.Queries;
using book.Domain.Entities.pagination;
using book.Test.Common;
using book.Test.Tests.CommentController.Test.Data;
using FluentAssertions;
using Newtonsoft.Json;
using Xunit;

namespace book.Test.Tests.CommentController.Test
{
    public class Comment_Test : ClientProvider
    {
        [Fact]
        public async Task AddComment_ShouldResponseBool()
        {
            //tested..works fine
            await AuthenticateMeBabyAsync() ; 
            var command = new AddCommentCommand
            {
                Description = "خیلی خوبه خوشم اومد"  , 
                bookId = "083c9930-3327-4d28-86fa-b4c830c7e188"
            } ; 
            var response = await Client.PostAsJsonAsync("api/comment" , command) ;
            var content = await response.Content.ReadAsAsync<Response<bool>>() ; 
            content.Item.Should().Be(true) ;  
        }
        [Fact]
        public async Task GetSingleComment_ResponseBool()
        {
            // tested..works fine
            await AuthenticateMeBabyAsync() ;
            var commentId = "1748e85e-206f-421e-8a2f-4cf06acc9e65" ; 
            var response = await Client.GetAsync($"api/comment/{commentId}") ; 
            var conent = await response.Content.ReadAsAsync<Response<CommentResource>>() ;
            conent.Errors.Should().BeNull() ; 
        }
        [Theory]
        [ClassData(typeof(CommentPaginationData))]
        public async Task GetFilteredCommentsPerPaged_ReturnPagedList(GetCommentsQuery query)
        {
            // tested..works fine
            await AuthenticateMeBabyAsync() ;
            var queryString = TextMaker.QueryStringCreator<GetCommentsQuery>(query , "/api/comment/filter?") ; 
            var response = await Client.GetAsync(queryString) ;
            var content = await response.Content.ReadAsAsync<Response<List<CommentResource>>>() ;  
            content.Status.Should().Be(StatusCodeEnum.OK) ; 
        }

        [Fact]
        public async Task RemoveComment_ShouldReturnResponseBool()
        {
            //tested..works fine
            await AuthenticateMeBabyAsync()  ; 
            string commentId = "1ad4353b-c203-4ed2-9ca7-a6565160e9ab" ; 
            var response = await Client.SendAsync(RemoveRequestCreator(commentId)) ; 
            var content = await response.Content.ReadAsAsync<Response<bool>>() ; 
            content.Item.Should().Be(true) ; 
        }
        private HttpRequestMessage RemoveRequestCreator(string commentId)
        {
            var req = new HttpRequestMessage(HttpMethod.Delete ,$"/api/comment/{commentId}") ; 
            return req ; 
        }

    }
}