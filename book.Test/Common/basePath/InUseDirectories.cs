using System.IO;

namespace book.Test.Common.basePath
{
    public class InUseDirectories : BaseDirectory
    {
        protected string BookPhotos 
        {
            get 
            {
                return Path.Combine(CurrentDirectory , "files" , "pics" , "book") ; 
            }
        }
        protected string BookFiles 
        {
            get 
            {
                return Path.Combine(CurrentDirectory , "files" , "books") ; 
            }
        }
        protected string UserPhotos 
        {
            get 
            {
                return Path.Combine(CurrentDirectory , "files" , "pics" , "user") ; 
            }
        } 
    }
}