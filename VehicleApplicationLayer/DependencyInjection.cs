using FluentValidation.AspNetCore;
using Infrastructure.Entity.Context;
using Microsoft.EntityFrameworkCore;
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
            services.AddDbContext<VehicleDbContext>(
               options => options.UseSqlServer(configuration.GetConnectionString("MsSqlDB"))
           );
            //register db contesxt
            //Register other services and interfaces
            return services;
        }
    }
}
