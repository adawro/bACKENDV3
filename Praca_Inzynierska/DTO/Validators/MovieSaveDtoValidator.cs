using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Praca_Inzynierska.DTO.Validators
{
    public class MovieSaveDtoValidator : AbstractValidator<MovieSaveDto>
    {
        public MovieSaveDtoValidator()
        {
            RuleFor(x => x.Title)
                .NotEmpty()
                .WithMessage("Pole tytuł nie moze byc puste")
                .MaximumLength(50)
                .WithMessage("Pole tytuł moze zawierac od 1 do 50 znakow");
            RuleFor(x => x.Description)
                .NotEmpty()
                .WithMessage("Pole opis nie moze byc puste")
                .MaximumLength(1000)
                .WithMessage("Pole opis moze zawierac od 1 do 1000 znakow");
            RuleFor(x => x.DirectionBy)
                .NotEmpty()
                .WithMessage("Pole Reżyseria nie moze byc puste");
            RuleFor(x => x.WrittenBy)
                .NotNull()
                .WithMessage("Pole scenariusz nie moze byc puste");
            RuleFor(x => x.BoxOffice)
                .NotEmpty()
                .WithMessage("Pole boxoffice nie moze byc puste");
            RuleFor(x => x.Country)
               .NotEmpty()
               .WithMessage("Pole kraj nie moze byc puste")
               .MaximumLength(50)
               .WithMessage("Pole kraj moze zawierac od 1 do 50 znakow");

        }
    }
}
