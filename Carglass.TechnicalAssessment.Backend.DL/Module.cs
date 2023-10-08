using Autofac;
using Carglass.TechnicalAssessment.Backend.DL.Repositories;
using Carglass.TechnicalAssessment.Backend.DL.Repositories._Base.Interfaces;
using Carglass.TechnicalAssessment.Backend.DL.Repositories.InMemory.Clients;
using Carglass.TechnicalAssessment.Backend.DL.Repositories.InMemory.Products;
using Carglass.TechnicalAssessment.Backend.Entities;


namespace Carglass.TechnicalAssessment.Backend.DL;

public class Module : Autofac.Module
{
    protected override void Load(ContainerBuilder builder)
    {
        RegisterRepositories(builder);
    }

    private static void RegisterRepositories(ContainerBuilder builder)
    {
        // TODO Implement repositories DI        
        builder.RegisterType<ClientIMRepository>().As<ICrudClientRepository>();
        builder.RegisterType<ClientDaoRepository>().As<IDataClientRepository>();
        
        builder.RegisterType<ProductIMRepository>().As<ICrudProductRepository>();
        builder.RegisterType<ProductDaoRepository>().As<IDataProductRepository>();

    }
}