using FluentValidation.Validators;
using Microsoft.AspNetCore.Http;
using System.IO ;
using System.Linq;

namespace book.Application.Validations.CustomValidators
{
    public class BookFileTypePropertyValidator : PropertyValidator
    {
        // public BookFileTypePropertyValidator() : base("فایل وارد شده معتبر نمیباشد")
        // {
            
        // }
        protected override bool IsValid(PropertyValidatorContext context) 
        {
            var file = context.PropertyValue as IFormFile ; 
           return isTypeValid(file)  ;
        }
        private bool isTypeValid(IFormFile file) {
           
            
                var result = Path.GetExtension(file.FileName).Substring(1) ;

                return SupportedType().Where(type => type==result).Any() ;
        }
        private string[] SupportedType() {
            return new string[] {"pdf"} ; 
        }
    }
}