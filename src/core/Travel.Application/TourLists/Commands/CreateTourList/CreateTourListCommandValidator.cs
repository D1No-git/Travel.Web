using FluentValidation;
using Travel.Application.Common.Interfaces;

namespace Travel.Application.TourLists.Commands.CreateTourList
{
    /// <summary>
    /// The preceding code is a validator of CreateTourListCommand, and we are using 
    /// RuleFor here from the FluentValidation package.
    /// RuleFor is a builder of validation rules for a particular property.That said,
    /// FluentValidation is a validation library that replaces Data Annotations.You
    /// should use this inst/// ead of Data Annotations because it helps you to write clean and
    /// maintainable code.
    /// </summary>
    public class CreateTourListCommandValidator : AbstractValidator<CreateTourListCommand>
    {
        private readonly IApplicationDbContext _context;

        public CreateTourListCommandValidator(IApplicationDbContext context)
        {
            _context = context;

            RuleFor(v => v.City)
              .NotEmpty().WithMessage("City is required.")
              .MaximumLength(200).WithMessage("City must not exceed 90 characters.");

            RuleFor(v => v.Country)
              .NotEmpty().WithMessage("Country is required")
              .MaximumLength(200).WithMessage("Country must not exceed 60 characters.");

            RuleFor(v => v.About)
              .NotEmpty().WithMessage("About is required");
        }
    }
}