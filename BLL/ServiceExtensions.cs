using Microsoft.Extensions.DependencyInjection;
using AutoMapper;
using FluentValidation.AspNetCore;
using Core.Validations;
using Core.Helpers;

namespace Core
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
