using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using ApiCrud.Business.Services.Implementations;
using ApiCrud.Business.Services.Interface;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace ApiCrud.Business
{
    public static class BusinessRegistrations 
    {
        public static void AddBusinessService(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(BusinessRegistrations));
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddControllers().AddFluentValidation(c => c.RegisterValidatorsFromAssembly(Assembly.GetExecutingAssembly()));
        
        }
            
            
        }
    }

