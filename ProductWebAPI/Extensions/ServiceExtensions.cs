using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ProductWebAPI.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductWebAPI.Extensions
{
    public static class ServiceExtensions
    {
        public static void ConfigureDbContext(this IServiceCollection services)
        {
            services.AddDbContext<ProductContext>(o => o.UseInMemoryDatabase("ProductDatabase"));
        }

        //public static void Configure 
    }
}
