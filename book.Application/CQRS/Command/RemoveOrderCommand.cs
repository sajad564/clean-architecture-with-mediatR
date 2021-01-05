using System;
using book.Application.common;
using book.Domain.Common;
using MediatR;

namespace book.Application.CQRS.Command
{
    public class RemoveOrderCommand :BaseInformation ,  IRequest<Response<bool>>
    {
        public string OrderId {get;set;}
        public RemoveOrderCommand(string Id)
        {
            this.OrderId = Id ; 
        }
    }
}