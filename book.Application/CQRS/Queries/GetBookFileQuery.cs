using book.Application.common ;
using book.Application.common.Resources;
using book.Domain.Entities;
using MediatR;

namespace book.Application.CQRS.Queries
{
    public class GetBookFileQuery : BaseInformation , IRequest<Response<FileResource>> 
    {
        public string Bookid {get;set;}
        public GetBookFileQuery(string Bookid)
        {
            this.Bookid = Bookid ; 
        }
    }
}