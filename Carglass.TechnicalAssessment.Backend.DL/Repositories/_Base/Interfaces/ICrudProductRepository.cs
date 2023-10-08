using Carglass.TechnicalAssessment.Backend.Entities;
using Carglass.TechnicalAssessment.Backend.Entities.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carglass.TechnicalAssessment.Backend.DL.Repositories._Base.Interfaces
{
    public interface ICrudProductRepository : ICrudRepository<Product>
    {
        List<string> validarDuplicados(Product? item);
    }
}
