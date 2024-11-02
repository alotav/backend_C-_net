﻿using Backend.DTOs;
using FluentValidation;

namespace Backend.Validators
{
    public class BeerUpdateValidator : AbstractValidator<BeerUpdateDto> 
    {
        public BeerUpdateValidator() 
        {
            RuleFor(x => x.Id).NotEmpty().WithMessage("El ID es obligatorio.");
            RuleFor(x => x.Name).NotEmpty().WithMessage("El nombre es obligatorio.");
            RuleFor(x => x.Name).Length(2, 20).WithMessage("El largo de ser de 2 a 20 caracteres.");
            RuleFor(x => x.BrandId).NotNull().WithMessage(x => "La marca es obligatoria.");
            RuleFor(x => x.BrandId).GreaterThan(0).WithMessage(x => "Error con el valor enviado de la marca.");
            RuleFor(x => x.Alcohol).GreaterThan(0).WithMessage(x => "El {PropertyName} debe ser mayor a cero.");
        }
    }
}
