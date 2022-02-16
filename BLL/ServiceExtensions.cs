using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using BLL.DTO;
using DAL.Entities;
using FluentValidation.AspNetCore;
using FluentValidation;
using BLL.Validations;
using BLL.Helpers;

namespace BLL
{
    public static class ServiceExtensions
    {
        public static void AddCustomServices(this IServiceCollection services)
        {
            services.AddScoped<IGenreService, GenreService>();
            // MovieService
            //...
        }

        public static void AddAutoMapper(this IServiceCollection services)
        {
            var configures = new MapperConfiguration(mc =>
            {
                mc.AddProfile<MapperProfile>();
                //mc.CreateMap<Genre, GenreDTO>().ReverseMap();
                //...
            });

            IMapper mapper = configures.CreateMapper();
            services.AddSingleton(mapper);
        }

        public static void AddFluentValidation(this IServiceCollection services)
        {
            services.AddFluentValidation(c => c.RegisterValidatorsFromAssemblyContaining<GenreValidator>());
            //services.AddTransient<IValidator<GenreDTO>, GenreValidator>();
        }
    }
}
