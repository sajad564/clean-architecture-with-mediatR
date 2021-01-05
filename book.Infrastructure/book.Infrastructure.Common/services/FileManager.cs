using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using book.Domain.Common;
using book.Domain.Enums;
using book.Domain.Interfaces.services;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;

namespace book.Infrastructure.Common.services
{
    public class FileManager : IFileManager
    {
        private string BasePath {get;set;}
        private string BaseUrl = "http://localhost:5000" ; 
        public FileManager(IHostingEnvironment env)
        {
            
            this.BasePath = env.WebRootPath ; 
        }
        public async Task<UploadedFileData> AddFileAsync(IFormFile file,FileTypeEnum type)
        {
            var FolderPath = GeneratePathByFileType(type) ;
            
            var uploadedFileData  = await UploadAsync(file,FolderPath) ;
            return uploadedFileData ; 
            
        }

        public  bool DeleteFile(string source ) 
        {
            try {
                  File.Delete(source);
            }
            catch {
                return false ;
            }
            return true ;
        }
        private string GeneratePathByFileType(FileTypeEnum type) {
            string fileFolderPerType = null ;  
            switch(type) {
                case FileTypeEnum.BookFile : 
                    fileFolderPerType = $"{BasePath}/book/files" ; 
                    break ;
                case FileTypeEnum.BookPhoto :
                    fileFolderPerType = $"{BasePath}/book/Imgs" ; 
                    break ;
                case FileTypeEnum.UserPhoto : 
                    fileFolderPerType = $"{BasePath}/user/Imgs" ;
                    break ;  
            }
            CreateDirectoryIfDoesNotExist(fileFolderPerType) ;
            return fileFolderPerType ;  

            
        }
        private void CreateDirectoryIfDoesNotExist(string directory) {
            if(!Directory.Exists(directory)) {
                Directory.CreateDirectory(directory) ; 
            }
        }
        private async Task<UploadedFileData> UploadAsync(IFormFile file , string FolderPath ) {
            
            string UniqueFileName = Guid.NewGuid() + file.FileName.Replace('/','_') ;
             string fileFullPath = $"{FolderPath}/{UniqueFileName}" ; 
             using(var stream = new FileStream(fileFullPath , FileMode.Create , FileAccess.Write)) {
                 await file.CopyToAsync(stream) ; 
             }
             var uploadFileData = new UploadedFileData {
                 Path  = fileFullPath , 
                 Url = fileFullPath.Replace(BasePath, BaseUrl) 
             } ;
             return uploadFileData ;  
        }

        public async Task<IEnumerable<UploadedFileData>> AddMultipleFileAsync(IEnumerable<IFormFile> files, FileTypeEnum type)
        {
            List<UploadedFileData> data = new List<UploadedFileData>() ; 
             foreach (var file in files)
            {
                var uploadedfiledata = await AddFileAsync(file , type) ;
                data.Add(uploadedfiledata) ;
            }
            return data ;
        }

        
    }
}