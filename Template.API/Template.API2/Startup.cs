using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Application.Services;
using CAPA_DATO.Queries;
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
            var conecctionString = Configuration.GetSection("ConnectionString").Value;
            // EF CORE 
            services.AddDbContext<ContextApplication>(option => option.UseSqlServer(conecctionString));

            //SQLKATA
            services.AddTransient<Compiler, SqlServerCompiler>();
            services.AddTransient<IDbConnection>(b =>
            {
                return new SqlConnection(conecctionString);
            });
            services.AddTransient<IGenericsRepositoty, GenericRepository>();
            services.AddTransient<ICarritoService, CarritoService>();
            services.AddTransient<IClienteService, ClienteService>();
            services.AddTransient<IProductoServices, ProductoServices>();
            services.AddTransient<IVentaService, VentaService>();
            services.AddTransient<IVentaQuery, VentaQuery>();
            services.AddTransient<ICarritoProductoService, CarritoProductoService>();
            services.AddTransient<IClienteQuery, ClienteQuery>();
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
