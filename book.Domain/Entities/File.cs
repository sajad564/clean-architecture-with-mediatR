using book.Domain.Common;

namespace book.Domain.Entities
{
    public class File : BaseFile
    {
        public Book Book {get;set;}
        public string BookId {get;set;}
    }
}