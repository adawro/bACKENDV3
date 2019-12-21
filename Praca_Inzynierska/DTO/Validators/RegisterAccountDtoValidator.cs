using FluentValidation;

namespace Praca_Inzynierska.DTO.Validators
{
    public class RegisterAccountDtoValidator : AbstractValidator<RegisterAccountDto>
    {
        public RegisterAccountDtoValidator()
        {
            RuleFor(x => x.UserName)
                .NotEmpty()
                .WithMessage("Pole nazwa uzytkownika nie moze byccccccccc puste");
            RuleFor(x => x.Email)
                .NotEmpty()
                .WithMessage("Pole Email nie moze byc puste")
                .EmailAddress()
                .WithMessage("Pole Email nie jest prawidlowym emailem");
            RuleFor(x => x.Name)
                .MaximumLength(20)
                .WithMessage("Pole Imie moze zawierac od 1 do 20 znakow");
            RuleFor(x => x.Surname)
                .MaximumLength(30)
                .WithMessage("Pole Imie moze zawierac od 1 do 30 znakow");
            RuleFor(x => x.Password)
                .NotEmpty()
                .WithMessage("Pole Haslo nie moze byc puste");
            RuleFor(x => x.ConfirmPassword)
                .NotEmpty()
                .WithMessage("Pole Powtorz Haslo nie moze byc puste")
                .Equal(x => x.Password)
                .WithMessage("Podane hasla sie nie zgadzaja");
        }
    }
}
