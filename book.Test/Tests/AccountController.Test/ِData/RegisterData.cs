

using System;
using System.IO;
using System.Net.Http;
using book.Application.CQRS.Command;
using Microsoft.AspNetCore.Http.Internal;
using Xunit;

namespace book.Test.Tests.AccountController.Test.Data
{
    public class RegisterData : TheoryData<MultipartFormDataContent>
    {
        // private readonly IHostingEnvironment env;
        public RegisterData()
        {
            UserList() ; 
        }
         
        private void UserList( ) 
        {
            
            for(int i=0 ;i<=6 ; i++ ) 
            {
                var uniqueKey =  Guid.NewGuid() ; 
                var user = new RegisterUserCommand 
                {
                    Username = $"username{uniqueKey}" , 
                    Firstname = $"firstname{uniqueKey}" , 
                    Lastname = $"lastname{uniqueKey}" ,
                    Password = $"passwordA1@{uniqueKey}" ,
                    Photo = null , 
                    ConfirmPassword = $"passwordA1@{uniqueKey}" , 
                    Email = "taraham.supp@gmail.com"
                }  ;
                var formData = ConvertToFormData(user) ;  
                Add(formData) ; 
            }
            
        }
        public  FileStream GetPhoto() {
            return System.IO.File.OpenRead(ImagePath()) ; 
            
        }
        private  string ImagePath() {
            string binFolder = Directory.GetCurrentDirectory() ; 
            int currentDirectoryIndex = binFolder.IndexOf(@"\bin") ;
            string currentDirectory = binFolder.Substring(0 , currentDirectoryIndex + 1) ;  
            return Path.Combine(currentDirectory ,"files" , "pics\\user" , "index.jpg") ; 
        }
        private MultipartFormDataContent ConvertToFormData(RegisterUserCommand newUser) 
        {
            var formData = new MultipartFormDataContent() ;
             formData.Add(new StringContent(newUser.Username) , "Username") ; 
             formData.Add(new StringContent(newUser.Password) , "Password") ; 
             formData.Add(new StringContent(newUser.ConfirmPassword) , "ConfirmPassword") ; 
             formData.Add(new StringContent(newUser.Email) , "Email") ; 
             formData.Add(new StringContent(newUser.Firstname) , "Firstname") ; 
             formData.Add(new StringContent(newUser.Lastname) , "Lastname") ;
             formData.Add( new StreamContent(GetPhoto()) , "Photo" ,"myphoto.jpg") ;
             return formData ; 
        }

        
    }
}