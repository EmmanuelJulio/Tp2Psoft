using Dominio.Commands;
using CAPA_DOMINIO.DTOs;
using Dominio.Entities;
using Dominio.Queries;
using Microsoft.EntityFrameworkCore;
using SqlKata.Compilers;
using SqlKata.Execution;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using Dominio.DTOs;

namespace CAPA_DATO.Queries
{
    public class VentaQuery : IVentaQuery
    {
        private readonly IDbConnection connection;
        private readonly Compiler compiler;
        

        public VentaQuery(IDbConnection connection, Compiler compiler  )
        {
            this.connection = connection;
            this.compiler = compiler;
           
        }

        public List<VentaDTO> GetAllVentas()
        {
            var db = new QueryFactory(connection, compiler);
            var query = db.Query("Venta");
            var resulta = query.Get<VentaDTO>();
            return resulta.ToList();
        }

        public List<ListProductoVentas> GetProductoCOD(string codigo)
        {

            var db = new QueryFactory(connection, compiler);
          

            var query = db.Query("Venta")
                .Select(
                "Product.id AS Producto_id",
                "Product.Codigo AS Producto_Codigo",
                "Product.Marca AS Producto_Marca",
                "Product.Precio AS Producto_Precio"

            )

            .Join("Carro", "Carro.Id", "Venta.Carrito")
            .Join("Client", "Client.Id", "Carro.Cliente")
            .Join("CarritoYproducto", "CarritoYproducto.Carrito", "Carro.Id")
                .Join("Product", "Product.Id", "CarritoYproducto.Producto");
            

            var entity = query.Get<ListProductoVentas>();
            return entity.ToList();
       
        }

        public List<VentaReporteGETDtos> GetReportes()
        {
            var db = new QueryFactory(connection, compiler);
            var query = db.Query("Venta")
                .Select("Client.Id AS ClienteID",
                "Client.Nombre AS ClienteName",
                "Client.Apellido AS ClienteApellido",
                "Product.Id AS ProductoID",
                "Product.Codigo AS ProductoCodigo",
                "Product.Marca AS ProductoMarca",
                "Product.Nombre AS ProductoNombre",
                "Product.Precio AS ProductPrecio",
                "CarritoYproducto.Id AS CarritoYproductoID",
                "Carro.Id AS CarritoID",
                "Carro.Cliente AS CarritoClienteID",
                "Venta.Fecha",
                "Venta.Id AS Id_Venta",
                "Venta.Carrito"
                )
                .WhereDatePart("Day", "Venta.Fecha", 12).WhereDatePart("Month", "Venta.Fecha", 5).WhereDatePart("Year", "Venta.Fecha", 2020)
                .Join("Carro", "Carro.Id", "Venta.Carrito")
                .Join("Client", "Client.Id", "Carro.Cliente")
                .Join("CarritoYproducto", "CarritoYproducto.Carrito", "Carro.Id")
                .Join("Product", "Product.Id", "CarritoYproducto.Producto");


            var entity = query.Get<VentaReporteGETDtos>();
            return entity.ToList();




           

        }

      
    }
}
