using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApiCrud.DAL.Repositories.implementations;
using ApiCrud.DAL.Repositories.Interface;
using Microsoft.Extensions.DependencyInjection;

namespace ApiCrud.DAL
{
    public static class DALRegistrations
    {
        public static void AddDalService(this IServiceCollection services) 
        {
            services.AddScoped<ICategoryRepository , CategoryRepository>();
        }
    }
}
