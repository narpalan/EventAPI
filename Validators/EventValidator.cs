using FluentValidation;
using EventAPI.DTOs;

namespace EventAPI.Validators
{
    public class CreateEventValidator : AbstractValidator<CreateEventDto>
    {
        public CreateEventValidator()
        {
            RuleFor(x => x.Title).NotEmpty().MaximumLength(100);
            RuleFor(x => x.Description).NotEmpty().MaximumLength(500);
            RuleFor(x => x.Date).GreaterThan(DateTime.Now);
            RuleFor(x => x.Latitude).InclusiveBetween(-90, 90);
            RuleFor(x => x.Longitude).InclusiveBetween(-180, 180);
            RuleFor(x => x.Category).NotEmpty().MaximumLength(50);
        }
    }
}