using System.IO;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using book.Application.common;
using book.Application.common.Resources;
using book.Application.CQRS.Command;
using book.Test.Common;
using FluentAssertions;
using Newtonsoft.Json;
using Xunit;

namespace book.Test.Tests.FileController.Test
{
    public class File_Test : ClientProvider
    {
        [Theory]
        [InlineData("fe1a4be4-8fd3-4ca9-92d2-7e2be1b84cd4")]
        [InlineData("f4f5f1ef-40c8-41f2-b3f7-d9e8de1d20bf")]
        public async Task GetBookFile_ReturnFile(string bookId)
        {
            await AuthenticateMeBabyAsync() ; 
            var response = await Client.GetAsync($"api/file/{bookId}") ; 
            var genericResponse = await  response.Content.ReadAsAsync<Response<FileResource>>() ; 
            genericResponse.Item.Url.Should().NotBeNull() ; 
        }
        [Fact]
        public async Task UpdateUserProfilePhoto_ReturnResponseBool()
        {
            // tested..works fine
            await AuthenticateMeBabyAsync() ;
            
            var response = await Client.PutAsync("/api/file/userphoto" , FormDataMaker()) ; 
            var content = await response.Content.ReadAsAsync<Response<bool>>() ; 
            content.Item.Should().Be(true) ; 
             
        }
        [Theory]
        
        [InlineData("3ef6116d-f03a-4241-857a-b2ea53a24a98" , "21e16ab5-10a2-4a74-93fb-3833cc37a598")]
        [InlineData("3ef6116d-f03a-4241-857a-b2ea53a24a98" , "149e7c8d-657b-4913-a234-324990ec184a")]
        [InlineData("3ef6116d-f03a-4241-857a-b2ea53a24a98" , "bf48cb21-9bc8-4bc1-9863-15d8e170a6ad")]
        public async Task RemoveBookPhoto_returnResponseBook(string bookId , string PhotoId)
        {
            await AuthenticateMeBabyAsync() ; 
            var command = new RemoveBookPhotoCommand()
                {
                    BookId = bookId , 
                    PhotoId = PhotoId
                } ;
                var request = CreateDeleteRequest(command) ; 
                var response = await Client.SendAsync(request) ; 
                var content  = await request.Content.ReadAsAsync<Response<bool>>() ; 
                content.Item.Should().Be(true) ; 
                      
        }
        private HttpRequestMessage CreateDeleteRequest(RemoveBookPhotoCommand command)
        {
            var request = new HttpRequestMessage(HttpMethod.Delete , "/api/file") ; 
            request.Content = new StringContent(JsonConvert.SerializeObject(command) , Encoding.UTF8 , "application/json") ; 
            return request ; 
        }
        private MultipartFormDataContent FormDataMaker()
        {
            
            FileStream photo = UserPhoto() ; 
            var formData = new MultipartFormDataContent() ; 
            formData.Add(new StreamContent(UserPhoto()) , "Photo" , "myphoto.jpg")  ; 
            return formData ; 
        }
        private FileStream UserPhoto()
        {
            var newPhotoPath = Path.Combine(UserPhotos , "updatesuser.jpg") ; 
            return File.OpenRead(newPhotoPath) ;
        }
    }
}