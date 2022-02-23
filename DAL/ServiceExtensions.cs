using DAL.Data;
using Core.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Cinema.Infrastructure.Data;

namespace DAL
{
    public static class ServiceExtensions
    {
        public static void AddDbContext(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<CinemaDbContext>(options => options.UseSqlServer(connectionString));
        }

        //public static void AddRepository(this IServiceCollection services)
        //{
        //    //services.AddScoped<IRepository, BaseRepository>();
        //    services.AddScoped(typeof(IRepository<>), typeof(BaseRepository<>));
        //}

        public static void AddUnitOfWork(this IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();
        }
    }
}
