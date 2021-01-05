using System.IO;
using System.Linq;
using FluentValidation.Validators;
using Microsoft.AspNetCore.Http;

namespace book.Application.Validations.CustomValidators
{
    public class UserPhotoPropertyValidator : PropertyValidator
    {
        protected override bool IsValid(PropertyValidatorContext context)
        {
            return IsPhotoValid(context.PropertyValue as IFormFile) ; 
        }
        private bool IsPhotoValid(IFormFile photo) {
            if(photo!=null && photo.Length!=0) {
                return validTypes().Where(type => type== Path.GetExtension(photo.FileName).Substring(1)).Any() ; 
            }
            return false ;
        }
        private string[] validTypes() {
           return new string[] {"jpg","png","jfif"} ;
        }
    }
}