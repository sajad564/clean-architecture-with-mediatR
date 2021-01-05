using System.IO;

namespace book.Test.Common.basePath
{
    public class BaseDirectory
    {
        protected string CurrentDirectory
         {
            get 
            {
                var binFolder=  Directory.GetCurrentDirectory() ;
                int currentDirectoryIndex = binFolder.IndexOf(@"\bin") + 1 ; 
                return binFolder.Substring(  0 , currentDirectoryIndex) ;
            }
        }
    }
}