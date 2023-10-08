using AutoMapper;
using Carglass.TechnicalAssessment.Backend.DL.Repositories;
using Carglass.TechnicalAssessment.Backend.DL.Repositories._Base.Interfaces;
using Carglass.TechnicalAssessment.Backend.Dtos;
using Carglass.TechnicalAssessment.Backend.Entities;
using FluentValidation;
using System.Reflection;

namespace Carglass.TechnicalAssessment.Backend.BL;

internal class ClientAppService : IClientAppService
{
        
    private readonly ICrudClientRepository clientIMRepository;    
        
    private readonly IMapper autoMapper;
        
    private readonly IValidator<ClientDto> clientDtoValidator;
   

    // TODO Implement
    public ClientAppService(IMapper p_autoMapper, ICrudClientRepository clientRepository)
    {
        clientIMRepository = clientRepository;
        autoMapper = p_autoMapper;        
    }

    public IEnumerable<ClientDto> GetAll()
    {
        //Se cambia el nombre moneySpenders por clients
        var clients = clientIMRepository.GetAll();
        return autoMapper.Map<IEnumerable<ClientDto>>(clients);
    }

    public ClientDto GetById(int keyValues)
    {
        //Se cambia el nombre theOne por client
        var client = clientIMRepository.GetById(keyValues);
        return autoMapper.Map<ClientDto>(client);
    }


    /// <summary>
    /// Añade un nuevo cliente
    /// Se cambio el nombre newMoney por clientDTO
    /// </summary>
    /// <param name="client"></param>
    /// <exception cref="Exception"></exception>    
    public void Create(ClientDto client)
    {
        
        List<string>? listDuplicates = new List<string>();

        var entity = autoMapper.Map<Client>(client);
        listDuplicates = clientIMRepository.validarDuplicados(entity);

        if (null != clientIMRepository.GetById(client.Id))
        {
            listDuplicates.Add("Ya existe un cliente con este Id");                       
        }
        
        if(listDuplicates.Count > 0)
        {
            string errorMessage = string.Join(Environment.NewLine, listDuplicates);
            throw new Exception(errorMessage);
        }
        else
        {
            // TODO Implement
            ValidateDto(client);           
            clientIMRepository.Create(entity);
        }


    }


    /// <summary>
    /// Actualiza los datos del cliente enviado
    /// Se cambia el nombre aBitOfMakeup por client
    /// </summary>
    /// <param name="client"></param>
    /// <exception cref="Exception"></exception>
    public void Update(ClientDto client)
    {
        if (null == clientIMRepository.GetById(client.Id))
        {
            throw new Exception("No existe ningún cliente con este Id");
        }
        else
        {
            ValidateDto(client);
            var entity = autoMapper.Map<Client>(client);
            clientIMRepository.Update(entity);
        }

    }

    /// <summary>
    /// Elimina un cliente
    /// Se cambia el nombre byebyee por client
    /// </summary>
    /// <param name="client"></param>
    /// <exception cref="Exception"></exception>
    /// <exception cref="NotImplementedException"></exception>
    public void Delete(ClientDto client)
    {
        if (null == clientIMRepository.GetById(client.Id))
        {
            throw new Exception("No existe ningún cliente con este Id");
        }
        else
        {
            // TODO Implement
            ValidateDto(client);
            var entity = autoMapper.Map<Client>(client);
            clientIMRepository.Delete(entity);
        }
    }

    /// <summary>
    /// Valida la informacion del cliente
    /// Se cambia el nombre item por client
    /// </summary>
    /// <param name="item"></param>
    /// <exception cref="Exception"></exception>
    private void ValidateDto(ClientDto client)
    {
        var validationResult = clientDtoValidator.Validate(client);
        if (validationResult.Errors.Any())
        {
            //Se cambia el nombre toShowErrors por errorMessages
            string errorMessages = string.Join("; ", validationResult.Errors.Select(s => s.ErrorMessage));
            throw new Exception($"El cliente especificado no cumple los requisitos de validación. Errores: '{errorMessages}'");
        }
    }


  
    

}