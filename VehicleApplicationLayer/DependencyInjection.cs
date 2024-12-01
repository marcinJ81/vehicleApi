using FluentValidation.AspNetCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace VehicleApplicationLayer
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(DependencyInjection).Assembly));

            services.AddControllers()
             .AddFluentValidation(v =>
             {
                 v.ImplicitlyValidateChildProperties = true;
                 v.ImplicitlyValidateRootCollectionElements = true;
                 v.RegisterValidatorsFromAssembly(Assembly.GetExecutingAssembly());
             });

            //register db contesxt
            //Register other services and interfaces
            return services;
        }
    }
}
