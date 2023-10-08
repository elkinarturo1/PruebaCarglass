using FluentValidation;
using System.Text.RegularExpressions;

namespace Carglass.TechnicalAssessment.Backend.Dtos;

public class ClientDtoValidator : AbstractValidator<ClientDto>
{
    public ClientDtoValidator()
    {
        RuleFor(x => x.Id)
            .NotEqual(default(int))
            .WithMessage("El Id del cliente es necesario.");

        RuleFor(x => x.DocType)
            .NotEmpty()
            .WithMessage("El tipo de documento es necesario.")
            .MaximumLength(25)
            .WithMessage("El tipo de documento tiene una longitud máxima de 25 caracteres.");

        RuleFor(x => x.DocNum)
            .NotEmpty()
            .WithMessage("El número de documento es necesario.")
            .MaximumLength(12)
            .WithMessage("El número de documento tiene una longitud máxima de 12 caracteres.")
            .When(x => x.DocType == "nif")
            .Must(validNifDocNumFormat)
            .WithMessage("El número de documento no cumple con el formato de NIF (8 dígitos y 1 letra) cuando el tipo de documento es 'nif'.");

        RuleFor(x => x.Email)
            .NotEmpty()
            .WithMessage("El email es necesario.")
            .EmailAddress()
            .WithMessage("El email no cumple el formato adecuado.");

        // ... More validations (It is not necessary to create them)        

    }


    private bool validNifDocNumFormat(string docNum)
    {
        // Validar que el número de documento tenga exactamente 8 números y una letra al final
        return Regex.IsMatch(docNum, @"^\d{8}[A-Za-z]$");
    }

}
