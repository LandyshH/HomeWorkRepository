using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Homework11.Calculator;
using Homework11.CalculatorDependency;
using Homework11.Database;
using Homework11.ExceptionHandler;
using Homework11.ParallelCalculator;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Homework11
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
            services.AddLogging();
            services.AddScoped<IExceptionHandler, ExceptionHandler.ExceptionHandler>();
            services.AddScoped<ParallelCalculator.ParallelCalculator>();
            services.AddScoped<ICalculatorDependency, CalculatorDependency.CalculatorDependency>();
            services.AddScoped<IParallelCalculator, ParallelCalculatorCache>(provider =>
                new ParallelCalculatorCache(provider.GetRequiredService<ApplicationContext>(),
                    provider.GetRequiredService<ParallelCalculator.ParallelCalculator>()));
            services.AddControllersWithViews();
            services.AddDbContext<ApplicationContext>(options => 
                options.UseNpgsql(Configuration.GetConnectionString("DbCalculations")));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}