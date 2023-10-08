using Carglass.TechnicalAssessment.Backend.DL.Repositories._Base.Interfaces;
using Carglass.TechnicalAssessment.Backend.Entities;
using Carglass.TechnicalAssessment.Backend.Entities.Products;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carglass.TechnicalAssessment.Backend.DL.Repositories.InMemory.Products
{
    public class ProductDaoRepository : IDataProductRepository
    {
        /// <summary>
        /// Devuelve la ruta con el archivo Json que contiene la data
        /// </summary>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public string GetJsonFilePath()
        {
            try
            {
                string rutaProyecto = Path.Combine("..", "Carglass.TechnicalAssessment.Backend.DL");
                return Path.Combine(rutaProyecto, "Repositories\\InMemory\\Databases", "ProductsDB.json");
            }
            catch (Exception)
            {
                throw new Exception("No se pudo conectar a la base de datos");
            }
        }


        /// <summary>
        /// Lee y deserializa la data desde un archivo Json
        /// </summary>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public ICollection<Product> LoadClientsFromJsonFile()
        {

            string jsonClientes;
            string rutaArchivoJson = GetJsonFilePath();


            if (File.Exists(rutaArchivoJson))
            {
                jsonClientes = File.ReadAllText(rutaArchivoJson);
            }
            else
            {
                throw new Exception("No se pudo conectar a la base de datos");
            }

            return JsonConvert.DeserializeObject<List<Product>>(jsonClientes);
        }

    }
}
