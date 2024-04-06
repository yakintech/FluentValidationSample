﻿using FluentValidation;
using FluentValidationSample.Models.DTO;

namespace FluentValidationSample.Models.Validations
{
    public class CreateStudentRequestDtoValidator : AbstractValidator<CreateStudentRequestDto>
    {
        public CreateStudentRequestDtoValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Name is required");
            RuleFor(x => x.Surname).NotEmpty().WithMessage("Surname is required");
            RuleFor(x => x.Email).NotEmpty().WithMessage("Email is required").EmailAddress().WithMessage("Email is not valid");
            RuleFor(x => x.Phone).Length(10, 11).When(x => !string.IsNullOrEmpty(x.Phone)).WithMessage("Phone number must be 10 or 11 characters");

        }
    }
}
