using System;
using System.Threading;
using System.Threading.Tasks;
using book.Domain.Interfaces.Repositories;
using FluentValidation.Validators;

namespace book.Application.Validations.CustomValidators
{
    public class BookShouldExistPropertyValidator : AsyncValidatorBase
    {
        private readonly IBookRepository bookRepo;
        public BookShouldExistPropertyValidator(IBookRepository bookRepo) 
        {
            this.bookRepo = bookRepo;

        }
        protected override async Task<bool> IsValidAsync(PropertyValidatorContext context, CancellationToken cancellation)
        {
            return await bookRepo.GetByIdAsync(context.PropertyValue as string )!=null ? true : false ;
        }
    }
}