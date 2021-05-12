using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Order_Processing.BLL;
using Order_Processing.BLL.Interface;
using Order_Processing.Context;
using Order_Processing.Repository;
using Order_Processing.Repository.Interface;

namespace Order_Processing
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
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });
            services.AddCors(options => options.AddPolicy("ApiCorsPolicy", builder =>
            {
                builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
            }));

            ConfigureTransientServices(services);
            ConfigureRepositories(services);
            ConfigureEntityFramework(services);

            services.AddAutoMapper(typeof(Startup));
            services.AddControllers();
        }

        private static void ConfigureTransientServices(IServiceCollection services)
        {
            services.AddTransient<IOrderProcessingBll, OrderProcessingBll>();
        }

        private static void ConfigureRepositories(IServiceCollection services)
        {
            services.AddSingleton<IOrderProcessingRepository, OrderProcessingRepository>();
        }

        private static void ConfigureEntityFramework(IServiceCollection services)
        {
            var databaseName = "OrderDb";
            services.AddDbContext<OrderDbContext>(options => options.UseInMemoryDatabase(databaseName));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors("ApiCorsPolicy");
            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
