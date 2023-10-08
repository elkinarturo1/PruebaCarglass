using AutoMapper;
using Carglass.TechnicalAssessment.Backend.Dtos.Products;
using Carglass.TechnicalAssessment.Backend.Entities.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carglass.TechnicalAssessment.Backend.BL.Products.Converter
{
    public class ProductProfieConverter: Profile
    {

      public ProductProfieConverter()
        {
            CreateMap<Product, ProductDTO>();

            // Dto to Entity
            CreateMap<ProductDTO, Product>();
        }        
    }
}
