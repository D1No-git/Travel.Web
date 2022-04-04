using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Travel.Application.Common.Interfaces;
using Travel.identity.Helpers;
using Travel.Identity.Services;

namespace Travel.identity
{
    /// <summary>
    /// Here is the registered service in our dependency injection (DI) container that we 
    /// will register in Startup.cs in a bit. We are getting the object of AuthSettings
    /// in the appsettings.json file and registering a scoped lifetime for 
    /// UserService. The Secret key of AuthSettings is a sensitive string that must
    /// be stored in an environment variable or Azure Key Vault to protect it.
    /// </summary>

    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructureIdentity(this IServiceCollection services, IConfiguration config)
        {
            services.Configure<AuthSettings>(config.GetSection(nameof(AuthSettings)));
            services.AddScoped<IUserService, UserService>();

            return services;
        }
    }
}
