using System;
using System.Security;
using book.Application.common;
using book.Application.common.Exceptions;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace book.Api.Controllers
{
    [ApiController]
    [Route("api/Error")]
    [ApiExplorerSettings(IgnoreApi=true)]
   [Produces("application/json")]
    public class ErrorController : ControllerBase
    {
        public book.Application.common.Response<bool> Error()
        {
            var excetionDetail = HttpContext.Features.Get<IExceptionHandlerFeature>();
            if (excetionDetail.Error is ValidationsException x)
            {
                
                var result = x.Errors ; 
                return book.Application.common.Response.Fail<bool>(result, StatusCodeEnum.BADREQUEST, false);
                
             
            }
            if(excetionDetail.Error is SecurityException secExp)
            {
                return book.Application.common.Response.Fail<bool>("درخواست نامعتبر",  StatusCodeEnum.NOTAUTHORIZE) ; 
            }
            else
            {
                 
                return book.Application.common.Response.Fail<bool>("مشکلی در سرور پیش آمده است", StatusCodeEnum.INTERNALSERVEL, false);
            }

        }
    }
}