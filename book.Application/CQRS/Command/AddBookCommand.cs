using System;
using System.Collections.Generic;
using book.Application.common;
using book.Domain.Common;
using book.Domain.Enums;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace book.Application.CQRS.Command
{

    public class AddBookCommand : BaseInformation  , IRequest<Response<bool>>
    {
        public string BookName {get;set;}
        public int PageNumber {get;set;}
        public string Description {get;set;}
        public DateTime PublishedDate {get;set;}
        public decimal Price {get;set;}
        public int Category {get;set;}
        public IEnumerable<IFormFile> BookPhotos {get;set;}
        public IFormFile BookFile {get;set;}
    }
}