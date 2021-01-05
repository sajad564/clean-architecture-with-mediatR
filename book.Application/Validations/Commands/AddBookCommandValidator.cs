using book.Application.CQRS.Command;
using book.Application.Validations.CustomValidators;
using FluentValidation;

namespace book.Application.Validations.Commands
{
    public class AddBookCommandValidator : AbstractValidator<AddBookCommand>
    {
        public AddBookCommandValidator()
        {
            RuleFor(b => b.Userid).Must(userid => userid!=null && userid.Length>15).WithMessage("آیدی وارد شده معتبر نمیباشد") ; 
            RuleFor(b => b.BookName).Must(name => name!=null && name.Length>15).WithMessage("لطفا نام کتاب را وارد نمایید");
            RuleFor(b => b.PageNumber).NotEmpty().WithMessage("لطفا تعداد صفحات را وارد نمایید").Must(pagenumber => pagenumber>=4 && pagenumber<=2000).WithMessage("حداکثر تعداد صفحات مجاز 2000 صفحه میباشد") ; 
            RuleFor(b => b.Description).Must(dis => dis!=null && dis.Length>15).WithMessage("جزییات کتاب شما کمتر از حد انتظار است") ; 
            RuleFor(b => b.BookFile).Cascade(CascadeMode.Stop).Must(file => file!=null && file.Length>0).WithMessage("لطفا یک  فایل  انتخاب کنید").SetValidator(new BookFileTypePropertyValidator()).WithMessage("فرمت فایل وارد شده مجاز نمیباشد") ;
            RuleFor(b => b.BookPhotos).SetValidator(new BookPhotosPropertyValidator()).WithMessage("لطفا فرمت تصاویر را بررسی نمایید") ; 
            RuleFor(b => b.PublishedDate).Must(date => date!=null).WithMessage("لطفا زمان انتشار کتاب را ذکر کنید") ; 
        }
    }
}