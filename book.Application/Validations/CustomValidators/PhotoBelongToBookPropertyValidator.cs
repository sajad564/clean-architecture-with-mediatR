using System.Threading;
using System.Threading.Tasks;
using book.Domain.Interfaces.Repositories;
using FluentValidation.Validators;
using System.Linq ;
using book.Application.CQRS.Command;

namespace book.Application.Validations.CustomValidators
{
    public class PhotoBelongToBookPropertyValidator : AsyncValidatorBase
    {
        
        private readonly IPhotoRepository photoRepo;
        public PhotoBelongToBookPropertyValidator( IPhotoRepository photoRepo) : base("عملایت انجام نشد,لطفا مطمئن شوید عکس مورد نظر وجود دارد ") 
        {

            this.photoRepo = photoRepo;
        }
        protected override async Task<bool> IsValidAsync(PropertyValidatorContext context, CancellationToken cancellation)
        {
            var castContext = context.PropertyValue as RemoveBookPhotoCommand ; 
            var bookImgs = await photoRepo.GetImgsByBookIdAsync(castContext.BookId) ; 
            return bookImgs.Count()>=2 && bookImgs.Where(imgs => imgs.Id==castContext.PhotoId).Any()  ; 
        }
    }
}