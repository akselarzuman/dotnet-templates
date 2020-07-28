using System;
using System.Collections.Generic;
using System.Linq;
using Aksel.ModelValidators.FluentValidator;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace Aksel.ModelValidators.Module
{
    public static class ModelValidatorsModule
    {
        public static IServiceCollection RegisterModelValidatorDependencies(this IServiceCollection services)
        {
            services
                .AddTransient<IModelValidator, ModelValidator>()
                .AddSingleton<ModelValidatorFactory>();

            // register validators
            Type validatorType = typeof(IValidator);
            List<Type> types = typeof(AkselModelValidator).Assembly.GetTypes()
                                                .Where(m => validatorType.IsAssignableFrom(m) && !m.IsInterface && !m.IsAbstract)
                                                .ToList();

            foreach (Type type in types)
            {
                Type validatorInterfaceType = type.GetInterfaces()
                                                .FirstOrDefault(interfaceType => interfaceType.GetInterfaces().Contains(validatorType) && interfaceType.GetInterfaces().Length == 1);

                services.AddTransient(validatorInterfaceType, type);
            }

            services.AddTransient(factory =>
            {
                return (Func<Type, IValidator>)(key =>
                {
                    return (IValidator)factory.GetService(key);
                });
            });

            return services;
        }
    }
}