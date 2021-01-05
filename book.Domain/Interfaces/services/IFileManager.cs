using System.Collections.Generic;
using System.Threading.Tasks;
using book.Domain.Common;
using book.Domain.Enums;
using Microsoft.AspNetCore.Http;

namespace book.Domain.Interfaces.services
{
    public interface IFileManager
    {
         bool DeleteFile(string source) ;
         Task<UploadedFileData> AddFileAsync(IFormFile file,FileTypeEnum type) ;
         Task<IEnumerable<UploadedFileData>> AddMultipleFileAsync(IEnumerable<IFormFile> files,FileTypeEnum type)  ; 
    }
}