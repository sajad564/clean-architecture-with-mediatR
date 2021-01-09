using System.Net.Http;
using System.Threading.Tasks;
using book.Api;
using Microsoft.AspNetCore.Mvc.Testing;
using System.Net.Http.Headers ;
using book.Application.CQRS.Command;
using book.Application.common;
using book.Domain.Entities;
using book.Test.Common.basePath;
using System.Collections.Generic;
using System;

namespace book.Test.Common
{
    public class ClientProvider : InUseDirectories
    {
        private HttpClient _client {get;set;}
        private List<LoginUserCommand> _Users {get;set;}  
        public HttpClient Client {
            get
            {
                if(_client!=null) 
                {
                    return _client ; 
                }
                else
                {
                     _client = new WebApplicationFactory<Startup>().CreateClient() ; 
                    _client.Timeout = TimeSpan.FromSeconds(100) ;
                    return _client ; 
                }
            }
        }
        protected async Task AuthenticateMeBabyAsync()
        {
            InstensiateUsers() ; 
            var token = await GetTokenAsync() ; 
            Client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer" ,token) ; 
        }
        private async Task<string> GetTokenAsync()
        {
            var response = await Client.PostAsJsonAsync("/api/account/login" ,SelectRandomUserForLogin() ) ; 
            var result = await response.Content.ReadAsAsync<Response<Token>>() ;
            return result.Item.AccessToken; 
        }
        private LoginUserCommand SelectRandomUserForLogin()
        {
            var rand = new Random().Next(0,_Users.Count-1) ; 
            return _Users[rand] ; 
        }
        private void InstensiateUsers()
        {
            _Users = new List<LoginUserCommand>()
            { 
              new LoginUserCommand {Username ="ALf@12331" , password ="123@saJad3"} , 
            } ; 
        }
        
    }
}