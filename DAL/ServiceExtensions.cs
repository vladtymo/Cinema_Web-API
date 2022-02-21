using DAL.Data;
using DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace DAL
{
    public static class ServiceExtensions
    {
        public static void AddDbContext(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<CinemaDbContext>(options => options.UseSqlServer(connectionString));
        }

        public static void AddRepository(this IServiceCollection services)
        {
            //services.AddScoped<IRepository, BaseRepository>();
            services.AddScoped(typeof(IRepository<>), typeof(BaseRepository<>));
        }
    }
}
