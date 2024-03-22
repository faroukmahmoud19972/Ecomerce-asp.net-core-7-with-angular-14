using Ecom.core.Interfaces;
using Ecom.infrastructure.Data;
using Ecom.infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecom.infrastructure
{
    public static class InfrastructureRegistration
    {
       public static  IServiceCollection InfrastructureConfiguration (this IServiceCollection services ,IConfiguration configuration)
        {
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));

            //services.AddScoped<ICategoryRepository, CategoryRepository>();
            //services.AddScoped<IProductRepository, ProductRepository>();

            services.AddScoped<IUnitOfWork, UnitOfWork>();


            //configure db : 
                services.AddDbContext<ApplicationDBContext>(
                     opt => opt.UseSqlServer(
                                    configuration.GetConnectionString("defualtconnection")
                              )
                        );

            return services;
        }
       
    }
}
