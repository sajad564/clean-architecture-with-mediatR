using System.Collections.Generic;
using System.IO;
using book.Test.Common.basePath;

namespace book.Test.Tests.BookController.Test.Data
{
    public class BookFiles : InUseDirectories
    {
        public FileStream GetBookFile()
        {
            return File.OpenRead(Path.Combine(BookFiles , "mybook.pdf")) ; 
        }
        public List<FileStream> GetBookPhotos()
        {
            var photos = new List<FileStream>() ;
            for(int i=1 ; i<=3 ; i++)
            {
                var photoPath = Path.Combine(BookPhotos , $"book{i}.jpg") ; 
                photos.Add(File.OpenRead(photoPath)) ; 
            }
            return photos ;
        }
    }
}