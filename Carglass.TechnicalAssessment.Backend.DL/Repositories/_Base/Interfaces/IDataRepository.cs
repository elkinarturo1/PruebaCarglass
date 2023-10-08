using Carglass.TechnicalAssessment.Backend.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carglass.TechnicalAssessment.Backend.DL.Repositories._Base.Interfaces
{
    public interface IDataRepository<TEntity>
    {
        ICollection<TEntity> LoadClientsFromJsonFile();
        string GetJsonFilePath();
    }
}
