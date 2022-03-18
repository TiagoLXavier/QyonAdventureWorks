using FluentValidation;

namespace QyonAdventureWorks.Business.Models.Validations
{
    public class CompetidorValidation : AbstractValidator<Competidor>
    {
        public CompetidorValidation()
        {
            RuleFor(c => c.Nome)
                .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido")
                .Length(2, 150).WithMessage("O campo {PropertyName} precisa ter entre {MinLength} e {MaxLength} caracteres");

            RuleFor(c => c.Sexo).Must(x => x.Equals("M") || x.Equals("F") || x.Equals("O")).WithMessage("O campo {PropertyName} precisa ser fornecido, Use somente: M, F, O");

            RuleFor(c => c.TemperaturaMediaCorpo).InclusiveBetween(36, 38).WithMessage("O valor do campo {PropertyName} deve estar entre 36 a 38");

            RuleFor(c => c.Peso)
            .GreaterThan(0).WithMessage("O campo {PropertyName} precisa ser maior que {ComparisonValue}");

            RuleFor(c => c.Altura)
            .GreaterThan(0).WithMessage("O campo {PropertyName} precisa ser maior que {ComparisonValue}");

        }
    }
}


