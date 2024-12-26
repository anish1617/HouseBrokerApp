using HouseBrokerApp.Domain.Interfaces;
using HouseBrokerApp.Infrastructure.Persistence;
using HouseBrokerApp.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HouseBrokerApp.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<HouseBrokerDbContext>(options => options.UseSqlServer(connectionString, sqlOptions => 
            sqlOptions.MigrationsAssembly("Infrastructure")));

            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

            return services;
        }
    }
}
