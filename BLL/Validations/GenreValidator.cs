using Core.DTO;
using FluentValidation;

namespace Core.Validations
{
    public class GenreValidator : AbstractValidator<GenreDTO>
    {
        public GenreValidator()
        {
            RuleFor(g => g.Name)
                .NotNull()
                .NotEmpty()
                .Matches(@"^[A-Z].*$").WithMessage("The property {PropertyName} must begin with upper case");
        }
    }
}
