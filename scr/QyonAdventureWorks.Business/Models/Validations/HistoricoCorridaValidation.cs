using FluentValidation;
using System;

namespace QyonAdventureWorks.Business.Models.Validations
{
    public class HistoricoCorridaValidation : AbstractValidator<HistoricoCorrida>
    {
        public HistoricoCorridaValidation()
        {
            RuleFor(c => c.CompetidorId)
           .GreaterThan(0).WithMessage("O campo {PropertyName} precisa ser maior que {ComparisonValue}");

            RuleFor(c => c.PistaCorridaId)
           .GreaterThan(0).WithMessage("O campo {PropertyName} precisa ser maior que {ComparisonValue}");

            RuleFor(c => c.DataCorrida)
             .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido")
            .LessThan(p => DateTime.Now).WithMessage("O campo {PropertyName} fornecida é uma Data Futura");

            RuleFor(c => c.TempoGasto)
            .GreaterThan(0).WithMessage("O campo {PropertyName} precisa ser maior que {ComparisonValue}");

        }
    }
}

