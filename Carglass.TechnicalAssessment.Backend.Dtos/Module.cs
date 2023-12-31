﻿using Autofac;
using Carglass.TechnicalAssessment.Backend.Dtos.Products;
using FluentValidation;
using System.Reflection;

namespace Carglass.TechnicalAssessment.Backend.Dtos;

public class Module : Autofac.Module
{
    protected override void Load(ContainerBuilder builder)
    {
        RegisterValidators(builder);
    }

    private static void RegisterValidators(ContainerBuilder builder)
    {
        builder.RegisterType<ClientDtoValidator>().As<IValidator<ClientDto>>();
        builder.RegisterType<ProductDtoValidator>().As<IValidator<ProductDTO>>();
    }
}