using Domain.Interfaces;
using Infrastructure;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace InquiryAPI
{
    public static class ServicesConfiguration
    {

        public static void ConfigureRepositories(IServiceCollection services, string connString)
        {         
            services.AddDbContext<CustomerContext>(c =>
            {                
                c.UseSqlServer(connString);

            });
            services.AddScoped(typeof(ICustomersRepository), typeof(CustomersRepository));
        }

    }
}
