using System.Collections.Generic;
using System.IO;
using System.Linq;
using FluentValidation.Validators;
using Microsoft.AspNetCore.Http;

namespace book.Application.Validations.CustomValidators
{
    public class BookPhotosPropertyValidator : PropertyValidator
    {
        protected override bool IsValid(PropertyValidatorContext context)
        {
            IEnumerable<IFormFile> files = context.PropertyValue as IEnumerable<IFormFile> ; 
            if(  files!=null && files.Any()) {
                           return ValidatePhotos(files ) ;
            }
            return false ;
           
           
        }

        private bool ValidatePhotos(IEnumerable<IFormFile> files) {
            return files.Where(f => !validateSinglePhoto(f)).Any() ? false : true ;
        }
        private bool validateSinglePhoto(IFormFile file) {
            if(file.Length!=0) {
                return ValidTypes().Where(vt => vt== Path.GetExtension(file.FileName).Substring(1)).Any() ;
            }
            return false ;
        }
        private string[] ValidTypes() {
            return new string[] {"jpg","png","jfif"} ;        }
        }
}