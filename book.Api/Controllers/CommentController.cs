using System;
using System.Threading.Tasks;
using book.Application.common;
using book.Application.common.Resources;
using book.Application.CQRS.Command;
using book.Application.CQRS.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using book.Domain.Entities.pagination ;
using Microsoft.AspNetCore.Authorization;
using book.Application.common.HelperClasses;
using System.Collections.Generic;
using System.Linq;

namespace book.Api.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class CommentController : ControllerBase
    {
        
        private readonly IMediator mediator;
        public CommentController(IMediator mediator)
        {
            this.mediator = mediator;

        }
        
        [HttpPost]
        [Authorize]
        public async Task<Response<bool>> AddComment([FromBody] AddCommentCommand newComment) {
            return await mediator.Send(newComment) ; 
        }
        [HttpGet("{Id}")]
        public async Task<Response<CommentResource>> GetComment(string Id) {
            return await mediator.Send(new GetCommentQuery(Id)) ; 
        }
        [AllowAnonymous]
        [HttpGet("[Action]")]
        public async Task<Response<List<CommentResource>>> Filter( [FromQuery] GetCommentsQuery query ) {
            var pagedComment =  await mediator.Send(query) ;
            Response.AddPaginationToHeader(new Pagination(pagedComment.Item.PageNumber ,pagedComment.Item.PageSize,pagedComment.Item.TotalPages , pagedComment.Item.TotalCount)) ;
            return book.Application.common.Response.Ok<List<CommentResource>>(pagedComment.Item.ToList()) ;
        }
        [HttpGet]
        public async Task<Response<List<CommentResource>>> GetComentsPerPost([FromQuery] GetBookCommentsQuery query)
        {
            var pagedComment =  await mediator.Send(query) ;
            Response.AddPaginationToHeader(new Pagination(pagedComment.Item.PageNumber ,pagedComment.Item.PageSize,pagedComment.Item.TotalPages , pagedComment.Item.TotalCount)) ;
            return book.Application.common.Response.Ok<List<CommentResource>>(pagedComment.Item.ToList()) ;
        }
        [Authorize]
        [HttpDelete("{Id}")]
        public async Task<Response<bool>> DeleteComment(string Id)
        {
            return await mediator.Send(new RemoveCommentCommand(Id)) ; 
        }
    }
}