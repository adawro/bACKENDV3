using FluentValidation;

namespace Praca_Inzynierska.DTO.Validators
{
    public class ActorSaveDtoValidator : AbstractValidator<ActorSaveDto>
    {
        public ActorSaveDtoValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .WithMessage("Pole imie nie moze byc puste")
                .MaximumLength(50)
                .WithMessage("Pole Imie moze zawierac od 1 do 50 znakow");
            RuleFor(x => x.Surname)
                .NotEmpty()
                .WithMessage("Pole nazwisko nie moze byc puste")
                .MaximumLength(50)
                .WithMessage("Pole nazwisko moze zawierac od 1 do 50 znakow");
            RuleFor(x => x.CityBorn)
                .NotEmpty()
                .WithMessage("Pole miasto urodzenia nie moze byc puste");
            RuleFor(x => x.CountryBorn)
                .NotEmpty()
                .WithMessage("Pole kraj urodzenia nie moze byc puste");
            RuleFor(x => x.Born)
                .NotNull()
                .WithMessage("Pole data urodzenia nie moze byc puste");
            RuleFor(x => x.CV)
                .NotEmpty()
                .WithMessage("Pole data urodzenia nie moze byc puste")
                .MaximumLength(300)
                .WithMessage("Pole zyciorys nie moze miec wiecej niz 300 znakow");
        }
    }
}
