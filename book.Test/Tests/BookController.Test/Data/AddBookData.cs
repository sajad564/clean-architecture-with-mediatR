using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using book.Application.CQRS.Command;
using book.Domain.Enums;
using Xunit;
namespace book.Test.Tests.BookController.Test.Data
{
    public class AddBookData : TheoryData<MultipartFormDataContent>
    {
       private FileStream Pdf {get;set;}
       private List<FileStream> Photos {get;set;}
       public AddBookData()
       {
           var bookFiles = new BookFiles() ;
           Pdf = bookFiles.GetBookFile() ; 
           Photos = bookFiles.GetBookPhotos() ; 
           for(int i =1; i<=5 ; i++)
           {
               Add(GetFormData()) ; 
           }  
       }
       private MultipartFormDataContent GetFormData()
       {
           var command = GetBookCommandObject()  ;
           var formData = new MultipartFormDataContent() ; 
           formData.Add(new StringContent(command.Price.ToString()) , "Price") ;
           formData.Add(new StringContent(command.BookName) , "BookName") ;
           formData.Add(new StringContent(command.PublishedDate.ToString())  , "PublishedDate") ; 
           formData.Add(new StringContent(command.Description) , "Description") ; 
           formData.Add(new StringContent(command.PageNumber.ToString()) , "PageNumber") ; 
           formData.Add(new StreamContent(Pdf) , "BookFile" , $"{Guid.NewGuid()}BookFile.pdf") ;
           formData.Add(new StringContent(command.Category.ToString()) ,"Category" )  ; 
           // add photos
           foreach(var photo in Photos) 
           {
               var uniqueName = Guid.NewGuid() +"Photo.jpg"  ;
               formData.Add(new StreamContent(photo) , "BookPhotos" , uniqueName) ; 
           }
           return formData ; 
       }
       private AddBookCommand GetBookCommandObject()
       {
           var uniqueKey = Guid.NewGuid() ; 
            var command = new AddBookCommand {
                BookName = "جنگو صلح" + uniqueKey  , 
                PageNumber = 392 , 
                Description = "کتاب جنگو صلح اثر لئون تولستوی" , 
                Category = new Random().Next(0,5)   , 
                PublishedDate = DateTime.Now , 
                Price = new Random().Next(10)
            } ; 
            return command ; 
       }
    }
}