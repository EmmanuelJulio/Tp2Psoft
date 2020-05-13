using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Application.Services;
using Datos;
using Datos.Comandos;
using Datos.Queries;
using Dominio.Commands;
using Dominio.Entities;
using Dominio.Queries;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.Web.CodeGeneration.EntityFrameworkCore;
using SqlKata.Compilers;

namespace Template.API2
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
            var connectionString = Configuration.GetSection("ConnectionString").Value;
            services.AddDbContext<ContextApplication>(options => options.UseSqlServer(connectionString));
            //sqlkata servicios
            //services.AddTransient<Compiler, SqlServerCompiler>();
            //services.AddTransient<IDbConnection>(b =>
            //{
            //    return new SqlConnection(connectionString);
            //});
            //Repositorio generico
          //  public static IServiceCollection AddTransient<TService>(this IServiceCollection services) where TService : class;
         //   services.AddTransient<IGenericRepository, GenericRepository>();
            //servicios de las endidades
           
            
            services.AddTransient<IRepositorio<Entidad> ,Repositorio<Entidad>>();
            services.AddTransient<IEntidadService<Entidad>, EntidadService>();
        //    services.AddTransient<IEntidadService<Producto>, ProductoService>();










            services.AddTransient<IProductoQuery, ProductoQuery>();

   
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

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
