using FluentValidation;
using System;

namespace Praca_Inzynierska.DTO.Validators
{
    public class ActorEditDtoValidator : AbstractValidator<ActorEditDto>
    {
        public ActorEditDtoValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .WithMessage("Pole imie nie moze byc puste")
                .MaximumLength(20)
                .WithMessage("Pole Imie moze zawierac od 1 do 20 znakow"); 
            RuleFor(x => x.Surname)
                .NotEmpty()
                .WithMessage("Pole nazwisko nie moze byc puste")
                .MaximumLength(30)
                .WithMessage("Pole nazwisko moze zawierac od 1 do 30 znakow");
            RuleFor(x => x.CityBorn)
                .NotEmpty()
                .WithMessage("Pole miasto urodzenia nie moze byc puste");
            RuleFor(x => x.CountryBorn)
                .NotEmpty()
                .WithMessage("Pole kraj urodzenia nie moze byc puste");
            RuleFor(x => x.Born)
                .NotEmpty()
                .WithMessage("Pole data urodzenia nie moze byc puste")
                .Must(BeAValidDate)
                .WithMessage("Początek daty jest wymagany");
            RuleFor(x => x.CV)
                .NotEmpty()
                .WithMessage("Pole data urodzenia nie moze byc puste")
                .MaximumLength(300)
                .WithMessage("Pole zyciorys nie moze miec wiecej niz 300 znakow");


        }
        private bool BeAValidDate(DateTime date)
        {
            return !date.Equals(default(DateTime));
        }
    }
}
