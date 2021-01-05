using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using book.Application.common;
using book.Application.common.Resources;
using book.Application.CQRS.Command;
using book.Domain.Entities;
using book.Test.Common;
using book.Test.Tests.AccountController.Test.Data;
using FluentAssertions;
using Xunit;

namespace book.Test.Tests.AccountController.Test
{
    public class Account_Test : ClientProvider
    {
        [Theory]
        [ClassData(typeof(RegisterData))]
        public async Task RegisterUser_Test(MultipartFormDataContent formData)
        {
             
             var response = await Client.PostAsync("/api/account" , formData) ; 
            var content = await response.Content.ReadAsAsync<Response<bool>>();   
            content.Status.Should().Be(StatusCodeEnum.OK) ; 
        }
        [Theory]
        [InlineData("sajad56412" , "123sajadA@")]
        public async Task LoginUser(string Username , string Password)
        {
            var loginCommand = new LoginUserCommand
                                {
                                    Username = Username , 
                                    password = Password 
                                } ; 
            var response = await Client.PostAsJsonAsync("/api/account/login" , loginCommand) ; 
            var result = await response.Content.ReadAsAsync<Response<Token>>() ; 
            result.Item.Should().NotBeNull() ; 
        }
        [Fact]
        public async Task UpdateUserInformation_retunResponseBoolType() 
        {
            await AuthenticateMeBabyAsync() ;
            var response = await Client.PutAsJsonAsync("/api/account" , new UpdateUserCommand {
                Username = "Vahid13" , 
                Firstname = "saharr" , 
                Lastname = "pour ebrahimi"
            })  ; 
            var result = await response.Content.ReadAsAsync<Response<bool>>() ;
            result.Item.Should().Be(true) ; 
        }
        [Theory]
        [InlineData("fe1a4be4-8fd3-4ca9-92d2-7e2be1b84cd4")]
        [InlineData("f4f5f1ef-40c8-41f2-b3f7-d9e8de1d20bf")]

        public async Task GetSingleBook_ReturnBookItem(string bookId)
        {
            var response = await Client.GetAsync($"api/book/{bookId}") ; 
            var content = await response.Content.ReadAsAsync<Response<BookResource>>() ;
            content.Item.Should().NotBeNull() ; 
        }
        [Theory]
        [InlineData("Taraham.supp@gmail.com")]
        public async Task RequestForConfirmLink_ShouldReturnBoolAndSendEmail(string email)
        {
            var response = await Client.GetAsync($"api/account/confirmemail/{email}") ;
            var content = await response.Content.ReadAsAsync<Response<bool>>() ; 
            content.Item.Should().Be(true) ; 
        }
        
    }
}