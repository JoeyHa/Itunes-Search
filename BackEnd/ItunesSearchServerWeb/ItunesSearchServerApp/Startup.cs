using ItunesSearchData;
using ItunesSearchData.Services;
using ItunesSearchServerApp.Controllers;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace ItunesSearchServerApp
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        readonly string myAllowSpecificOrigins = "AllowHeaders";

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ItunesSearchContext>(options =>
                options.UseNpgsql(Configuration.GetConnectionString("DefaultConnection"))
                );
            services.AddControllersWithViews();
            services.AddTransient<IAccountService, AccountService>();
            services.AddHttpClient<ISearchService, SearchService>();
            services.AddCors();
            //services.AddCors(options =>
            //{
            //    options.AddPolicy(myAllowSpecificOrigins,
            //    builder =>
            //    {
            //        builder.WithOrigins("http://localhost:3000")
            //                .AllowAnyHeader()
            //                .AllowAnyMethod()
            //                .AllowAnyOrigin();

            //    });
            //});



            //services.AddSpaStaticFiles(configuration =>
            //{
            //    configuration.RootPath = "ClientApp/build";
            //});

            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();
            //app.UseCors(myAllowSpecificOrigins);
            app.UseRouting();
            app.UseCors(
                options => options.WithOrigins("http://localhost:3000").AllowAnyMethod().AllowAnyOrigin().AllowAnyHeader()
            );
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
