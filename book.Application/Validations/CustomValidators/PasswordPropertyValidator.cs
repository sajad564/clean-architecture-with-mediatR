using System.Text.RegularExpressions;
using FluentValidation.Validators;

namespace book.Application.Validations.CustomValidators
{
    public class PasswordPropertyValidator : PropertyValidator
    {
        public PasswordPropertyValidator() : base("پسورد شما باید شامل حروف بزرگ و کوچک و حداقل یک عدد و علامت باشد") 
        {
            
        }
        protected override bool IsValid(PropertyValidatorContext context) 
        {
            return PasswordValidation(context.PropertyValue as string) ; 
        }
        private bool PasswordValidation(string password) {
           if(password!=null) {
               return RegexPasswordValidation(password) ; 
           }
           return false ;
        }
        private bool RegexPasswordValidation(string propertyValue) {
            var lowercase = new Regex("[a-z]+");
            var uppercase = new Regex("[A-Z]+");
            var digit = new Regex("(\\d)+");
            var symbol = new Regex("(\\W)+");
            return (lowercase.IsMatch(propertyValue) 
            && uppercase.IsMatch(propertyValue) 
            && digit.IsMatch(propertyValue) 
            && symbol.IsMatch(propertyValue)) ; 
        }
    }
}