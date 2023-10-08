using Carglass.TechnicalAssessment.Backend.DL.Repositories._Base.Interfaces;
using Carglass.TechnicalAssessment.Backend.DL.Repositories.InMemory.Products;
using Carglass.TechnicalAssessment.Backend.Entities;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Reflection;

namespace Carglass.TechnicalAssessment.Backend.DL.Repositories;

public class ClientIMRepository : ICrudClientRepository
{
    private ICollection<Client> _clients;
    private IDataClientRepository _clientRepository;

    public ClientIMRepository(IDataClientRepository dataClientRepository)
    {
        // Carga los datos de clientes desde el archivo JSON
        _clientRepository = dataClientRepository;   
        _clients = new HashSet<Client>(_clientRepository.LoadClientsFromJsonFile());
    }


    /// <summary>
    /// Devuelve todos los clientes
    /// </summary>
    /// <returns></returns>
    public IEnumerable<Client> GetAll()
    {
        // TODO Implement        
        return _clients;
    }

    public Client? GetById(int keyValue)
    {
        return _clients.SingleOrDefault(x => x.Id.Equals(keyValue));
    }

    public Client? GetByDocNum(string keyValue)
    {
        return _clients.SingleOrDefault(x => x.DocNum.Equals(keyValue));
    }

    public List<string> validarDuplicados(Client? item)
    {
        List<string> listResult = new List<string>();

        if(item.GetType().GetProperty("DocNum").Name == "DocNum")
        {
            var client = _clients.SingleOrDefault(x => x.DocNum.Equals(item.DocNum));
            listResult.Add("El valor de la propiedad DocNum esta duplicado, ya existe en el repositorio");             
        }

        return listResult;
          
    }

    /// <summary>
    /// Añade un nuevo cliente
    /// </summary>
    /// <param name="item"></param>
    public void Create(Client item)
    {
        // TODO Implement
        _clients.Add(item);
    }

    /// <summary>
    /// Actualiza el cliente enviado
    /// </summary>
    /// <param name="item"></param>
    /// <exception cref="InvalidOperationException"></exception>
    public void Update(Client item)
    {
        // TODO Implement
        Client clientOld = new Client();

        clientOld = _clients.Single(x => x.Id.Equals(item.Id));

        if (clientOld != null)
        {
            clientOld.Id = item.Id;
            clientOld.DocType = item.DocType;
            clientOld.DocNum = item.DocNum;
            clientOld.Email = item.Email;
            clientOld.GivenName = item.GivenName;
            clientOld.FamilyName1 = item.FamilyName1;
            clientOld.Phone = item.Phone;
        }
        else
        {
            throw new InvalidOperationException("No se pudo actualizar el cliente por que no se encontro el cliente a actualizar en base de datos");
        }

    }

    /// <summary>
    /// Eliminar un cliente
    /// </summary>
    /// <param name="item"></param>
    public void Delete(Client item)
    {
        var toDeleteItem = _clients.Single(x => x.Id.Equals(item.Id));
        _clients.Remove(toDeleteItem);
    }
      
}
