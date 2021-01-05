using System;
using System.Threading;
using System.Threading.Tasks;
using book.Domain.Interfaces.Repositories;
using FluentValidation.Validators;

namespace book.Application.Validations.CustomValidators
{
    public class ProductShouldExistPropertyValidator : AsyncValidatorBase
    {
        private readonly IBookRepository bookRepo;
        public ProductShouldExistPropertyValidator(IBookRepository bookRepo) : base("در خواست نا معتبر")
        {
            this.bookRepo = bookRepo;

        }
        protected override async Task<bool> IsValidAsync(PropertyValidatorContext context, CancellationToken cancellation)
        {
            return await bookRepo.GetByIdAsync(context.PropertyValue as string )!=null ? true : false ;
        }
    }
}