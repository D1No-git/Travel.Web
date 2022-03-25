using AutoMapper;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using Travel.Application.Common.Behaviors;

namespace Travel.Application
{
    /// <summary>
    /// The preceding code is a dependency injection container method. You will see here that 
    /// IServiceCollection is adding different kinds of services to the collection of the
    /// service descriptors.
    /// We will inject the static method, AddApplication, later in the Startup file so that the
    /// Web API project, particularly the Startup file, won't need to declare any dependencies 
    /// on third-party libraries such as AutoMapper because they are already declared in this file.
    /// </summary>
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            services.AddMediatR(Assembly.GetExecutingAssembly());

            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(PerformanceBehavior<,>));
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(UnhandledExceptionBehavior<,>));

            return services;
        }
    }
}