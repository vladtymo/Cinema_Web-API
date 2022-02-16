using BLL.DTO;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Validations
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
