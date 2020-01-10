using FluentValidation;
using System;

namespace Praca_Inzynierska.DTO.Validators
{
    public class CommentSaveValidator : AbstractValidator<CommentSaveDto>
    {
        public CommentSaveValidator()
        {
            RuleFor(x => x.CommentStrign)
                .MaximumLength(150)
                .WithMessage("Pole Imie moze zawierac maksymalnie 150 znakow");
            RuleFor(x => x.Ratio)
                .NotEmpty()
                .WithMessage("Podaj ocene ogloszenia")
                .GreaterThan(0)
                .WithMessage("Podaj poprawną ocene ogloszenia od 1 do 5")
                .LessThan(6)
                .WithMessage("Podaj poprawną ocene ogloszenia od 1 do 5");

        }

    }
}
