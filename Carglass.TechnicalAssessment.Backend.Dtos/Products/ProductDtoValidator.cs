using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carglass.TechnicalAssessment.Backend.Dtos.Products
{
    public class ProductDtoValidator:AbstractValidator<ProductDTO>
    {

        public ProductDtoValidator() {

           RuleFor(x => x.Id)
          .NotEqual(default(int))
          .WithMessage("El Id del producto es necesario.");

           RuleFor(x => x.ProductType)
          .NotEqual(default(int))
          .WithMessage("El tipo del producto es necesario.");

            RuleFor(x => x.ProductName)
                .NotEmpty()
                .WithMessage("El número de documento es necesario.")
                .MaximumLength(25)
                .WithMessage("El número de documento tiene una longitud máxima de 25 caracteres.");

        }

    }
}
