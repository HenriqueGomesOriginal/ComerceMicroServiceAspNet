/**
 * Author: Henrique Gomes
 * Date: 04 - 24 - 2022
 * 
 * This class is from .net 5 format, works perfect on .net 6
 */

using Catalog.API.Business;
using Catalog.API.Business.Implementation;
using Catalog.API.Repository;
using Catalog.API.Repository.Implementation;
using Microsoft.AspNetCore.Rewrite;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Net.Http.Headers;
using Microsoft.OpenApi.Models;
using Serilog;

namespace Catalog.API
{
    public class Startup
    {

        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;

            // Log config
            Log.Logger = new LoggerConfiguration()
                .WriteTo.Console()
                .CreateLogger();
        }

        public void ConfigureServices(IServiceCollection services)
        {
            // Media Type
            services.AddMvc(options =>
            {
                options.RespectBrowserAcceptHeader = true;

                options.FormatterMappings.SetMediaTypeMappingForFormat("xml", MediaTypeHeaderValue.Parse("application/xml"));
                options.FormatterMappings.SetMediaTypeMappingForFormat("json", MediaTypeHeaderValue.Parse("application/json"));
            })
                .AddXmlSerializerFormatters();

            // Version control
            services.AddApiVersioning();

            services.AddControllers();

            // Version control
            services.AddApiVersioning();

            // Dependency injection
            services.TryAddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            services.AddScoped<IProductsBusiness, ProductsBusiness>();
            services.AddScoped<IProductsRepository, ProductsRepository>();

            services.AddCors(options => options.AddDefaultPolicy(builder =>
            {
                builder.AllowAnyHeader()
                .AllowAnyMethod()
                .AllowAnyOrigin();
            }));

            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1",
                new OpenApiInfo
                {
                    Title = "DricCloudApiBack",
                    Version = "v1",
                    Description = "Developed in ASP.NET 6",
                    Contact = new OpenApiContact
                    {
                        Name = "Henrique Gomes",
                        Url = new Uri("https://github.com/HenriqueGomesOriginal"),
                        Email = "henriquegomesoriginal@gmail.com"
                    }
                });
            });
        }

        public void Configure(WebApplication app, IWebHostEnvironment environment)
        {
            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            app.UseStaticFiles();

            app.UseRouting();

            // Adding CORS, need to be in this location
            app.UseCors();

            app.UseAuthorization();

            var options = new RewriteOptions();
            options.AddRedirect("ˆ$", "swagger");
            app.UseRewriter(options);

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapControllerRoute("DefaultApi", "{controller=values}/{id?}");
            });
        }
    }
}
