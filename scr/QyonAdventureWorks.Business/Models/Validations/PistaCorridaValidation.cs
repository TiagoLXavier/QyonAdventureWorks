using FluentValidation;

namespace QyonAdventureWorks.Business.Models.Validations
{
    public class PistaCorridaValidation : AbstractValidator<PistaCorrida>
    {
        public PistaCorridaValidation()
        {
            RuleFor(c => c.Descricao)
                .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido")
                .Length(2, 50).WithMessage("O campo {PropertyName} precisa ter entre {MinLength} e {MaxLength} caracteres");
        }
    }
}
