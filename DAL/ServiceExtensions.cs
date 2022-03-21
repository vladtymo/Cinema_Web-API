using DAL.Data;
using Core.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Cinema.Infrastructure.Data;
using Microsoft.AspNetCore.Identity;

namespace DAL
{
    public static class ServiceExtensions
    {
        public static void AddDbContext(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<CinemaDbContext>(options => options.UseSqlServer(connectionString));
        }

        public static void AddIdentity(this IServiceCollection services)
        {
            services.AddIdentity<IdentityUser, IdentityRole>()
                .AddEntityFrameworkStores<CinemaDbContext>()
                .AddDefaultTokenProviders();
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
