using DAL;
using Core;
using Cinema_WebApi.Helpers;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace Cinema_WebApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            //services.AddDbContext<CinemaDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("LocalCinemaDbConnection")));
            services.AddDbContext(Configuration.GetConnectionString("LocalCinemaDbConnection"));

            //services.AddRepository();
            services.AddUnitOfWork();

            //services.AddSingleton<IRepository, Repository>();
            //services.AddScoped();
            //services.AddTransient();

            services.AddCustomServices();
            services.AddFluentValidation();
            services.AddAutoMapper();

            services.AddResponseCaching();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Cinema_WebApi", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            //app.Run(async (context) =>
            //{
            //    await context.Response.Body.WriteAsync(Encoding.UTF8.GetBytes("Hello from the first middleware!"));
            //});
            //app.Use(async (context, next) =>
            //{
            //    // doing something
            //    await next.Invoke();
            //});


            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Cinema_WebApi v1"));
            }

            app.UseHttpsRedirection();

            app.UseMiddleware<ErrorHandlerMiddleware>();

            app.UseRouting();

            app.UseResponseCaching();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
