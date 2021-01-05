using System;
using book.Application.common;
using book.Domain.Common;
using MediatR;

namespace book.Application.CQRS.Command
{
    public class AddOrderCommand : BaseInformation ,  IRequest<Response<bool>>
    {
        public string ProductId {get;set;}
        public AddOrderCommand(string ProductId)
        {
            this.ProductId = ProductId ; 
        }
    }
}