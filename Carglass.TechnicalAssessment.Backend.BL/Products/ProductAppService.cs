using AutoMapper;
using Carglass.TechnicalAssessment.Backend.DL.Repositories;
using Carglass.TechnicalAssessment.Backend.DL.Repositories._Base.Interfaces;
using Carglass.TechnicalAssessment.Backend.Dtos;
using Carglass.TechnicalAssessment.Backend.Dtos.Products;
using Carglass.TechnicalAssessment.Backend.Entities;
using Carglass.TechnicalAssessment.Backend.Entities.Products;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carglass.TechnicalAssessment.Backend.BL.Products
{
    internal class ProductAppService : IProductAppService
    {

        private readonly ICrudProductRepository productIMRepository;

        private readonly IMapper autoMapper;

        private readonly IValidator<ProductDTO> productDtoValidator;


        // TODO Implement
        public ProductAppService(IMapper p_autoMapper, ICrudProductRepository productRepository)
        {
            productIMRepository = productRepository;
            autoMapper = p_autoMapper;
        }

        public IEnumerable<ProductDTO> GetAll()
        {
            //Se cambia el nombre moneySpenders por clients
            var data = productIMRepository.GetAll();
            return autoMapper.Map<IEnumerable<ProductDTO>>(data);
        }

        public ProductDTO GetById(int keyValues)
        {
            //Se cambia el nombre theOne por client
            var data = productIMRepository.GetById(keyValues);
            return autoMapper.Map<ProductDTO>(data);
        }


        /// <summary>
        /// Añade un nuevo product
        /// </summary>
        /// <param name="product"></param>
        /// <exception cref="Exception"></exception>    
        public void Create(ProductDTO product)
        {
            List<string>? listDuplicates = new List<string>();

            var entity = autoMapper.Map<Product>(product);
            listDuplicates = productIMRepository.validarDuplicados(entity);

            if (null != productIMRepository.GetById(product.Id))
            {
                listDuplicates.Add("Ya existe un cliente con este Id");
            }

            if (listDuplicates.Count > 0)
            {
                string errorMessage = string.Join(Environment.NewLine, listDuplicates);
                throw new Exception(errorMessage);
            }
            else
            {
                // TODO Implement
                ValidateDto(product);
                productIMRepository.Create(entity);
            }


        }


        /// <summary>
        /// Actualiza los datos del product enviado
        /// </summary>
        /// <param name="product"></param>
        /// <exception cref="Exception"></exception>
        public void Update(ProductDTO product)
        {
            if (null == productIMRepository.GetById(product.Id))
            {
                throw new Exception("No existe ningún cliente con este Id");
            }
            else
            {
                ValidateDto(product);
                var entity = autoMapper.Map<Product>(product);
                productIMRepository.Update(entity);
            }

        }

        /// <summary>
        /// Elimina un cliente
        /// Se cambia el nombre byebyee por client
        /// </summary>
        /// <param name="client"></param>
        /// <exception cref="Exception"></exception>
        /// <exception cref="NotImplementedException"></exception>
        public void Delete(ProductDTO client)
        {
            if (null == productIMRepository.GetById(client.Id))
            {
                throw new Exception("No existe ningún cliente con este Id");
            }
            else
            {
                // TODO Implement
                ValidateDto(client);
                var entity = autoMapper.Map<Product>(client);
                productIMRepository.Delete(entity);
            }
        }

        /// <summary>
        /// Valida la informacion del cliente
        /// Se cambia el nombre item por client
        /// </summary>
        /// <param name="item"></param>
        /// <exception cref="Exception"></exception>
        private void ValidateDto(ProductDTO client)
        {
            var validationResult = productDtoValidator.Validate(client);
            if (validationResult.Errors.Any())
            {
                //Se cambia el nombre toShowErrors por errorMessages
                string errorMessages = string.Join("; ", validationResult.Errors.Select(s => s.ErrorMessage));
                throw new Exception($"El cliente especificado no cumple los requisitos de validación. Errores: '{errorMessages}'");
            }
        }



    }
}
