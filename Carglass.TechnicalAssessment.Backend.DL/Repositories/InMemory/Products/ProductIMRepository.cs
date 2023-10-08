using Carglass.TechnicalAssessment.Backend.DL.Repositories._Base.Interfaces;
using Carglass.TechnicalAssessment.Backend.Entities;
using Carglass.TechnicalAssessment.Backend.Entities.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carglass.TechnicalAssessment.Backend.DL.Repositories.InMemory.Products
{
    public class ProductIMRepository: ICrudProductRepository
    {
        private ICollection<Product> _products;
        private IDataProductRepository _productRepository;

        public ProductIMRepository(IDataProductRepository dataProductRepository)
        {
            // Carga los datos de clientes desde el archivo JSON
            _productRepository = dataProductRepository;
            _products = new HashSet<Product>(_productRepository.LoadClientsFromJsonFile());
        }

        /// <summary>
        /// Devuelve todos los productos
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Product> GetAll()
        {
            // TODO Implement        
            return _products;
        }

        public Product? GetById(int keyValue)
        {
            return _products.SingleOrDefault(x => x.Id.Equals(keyValue));
        }

        public Product? GetByDocNum(string keyValue)
        {
            return _products.SingleOrDefault(x => x.NumTerminal.Equals(keyValue));
        }

        public List<string> validarDuplicados(Product? item)
        {
            List<string> listResult = new List<string>();

            if (item.GetType().GetProperty("NumTerminal").Name == "NumTerminal")
            {
                var client = _products.SingleOrDefault(x => x.NumTerminal.Equals(item.NumTerminal));
                listResult.Add("El valor de la propiedad NumTerminal esta duplicado, ya existe en el repositorio");
            }

            return listResult;

        }

        /// <summary>
        /// Añade un nuevo producto
        /// </summary>
        /// <param name="item"></param>
        public void Create(Product item)
        {
            // TODO Implement
            _products.Add(item);
        }

        /// <summary>
        /// Actualiza el producto enviado
        /// </summary>
        /// <param name="item"></param>
        /// <exception cref="InvalidOperationException"></exception>
        public void Update(Product item)
        {
            // TODO Implement
            Product clientOld = new Product();

            clientOld = _products.Single(x => x.Id.Equals(item.Id));

            if (clientOld != null)
            {
                clientOld.Id = item.Id;
                clientOld.ProductName = item.ProductName;
                clientOld.ProductType = item.ProductType;
                clientOld.NumTerminal = item.NumTerminal;
                clientOld.SoldAt = item.SoldAt;             
            }
            else
            {
                throw new InvalidOperationException("No se pudo actualizar el cliente por que no se encontro el cliente a actualizar en base de datos");
            }

        }

        /// <summary>
        /// Eliminar un producto
        /// </summary>
        /// <param name="item"></param>
        public void Delete(Product item)
        {
            var toDeleteItem = _products.Single(x => x.Id.Equals(item.Id));
            _products.Remove(toDeleteItem);
        }
    }
}
