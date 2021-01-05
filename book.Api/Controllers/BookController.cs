
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using book.Application.common;
using book.Application.common.HeaderConvertors;
using book.Application.common.HelperClasses;
using book.Application.common.Resources;
using book.Application.CQRS.Command;
using book.Application.CQRS.Queries;
using book.Domain.Entities.pagination;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace book.Api.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    // [Authorize(Roles="admin")]
    // [Authorize(Roles="author")]
    public class BookController : ControllerBase
    {
        private readonly IMediator mediatr;
        public BookController(IMediator mediatr)
        {
            this.mediatr = mediatr;

        }
        [HttpPost]
        [Authorize(Roles="admin,author")]
        public async Task<Response<bool>>  AddBook([FromForm] AddBookCommand newBook) { 
            return await mediatr.Send(newBook) ; 
        }
       [AllowAnonymous]
       [HttpGet("{Id}")]
       public async Task<Response<BookResource>> GetBook(string Id) {
           return await mediatr.Send(new GetBookWithIdQuery(Id)) ; 
       }
       [AllowAnonymous]
       [HttpGet]
       public async Task<Response<List<BookResource>>> GetBooks([FromHeader] GetBooksPerPageQuery query) {
           query.ConvertToBookPagination(HttpContext) ;
           var pagedOrder =  await mediatr.Send(query) ;
            Response.AddPaginationToHeader(new Pagination(pagedOrder.Item.PageNumber ,pagedOrder.Item.PageSize,pagedOrder.Item.TotalPages , pagedOrder.Item.TotalCount)) ;
            return book.Application.common.Response.Ok<List<BookResource>>(pagedOrder.Item.ToList()) ;
       }
        [Authorize(Roles="admin,author")]
       [HttpDelete("{Id}")]
       public async Task<Response<bool>> RemoveBook(string Id) {
           return await mediatr.Send(new RemoveBookCommand(Id)) ; 
       }
       
    }
}