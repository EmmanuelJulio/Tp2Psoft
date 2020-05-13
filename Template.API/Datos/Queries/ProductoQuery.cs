using Dominio.Entities;
using Dominio.Queries;
using SqlKata.Compilers;
using SqlKata.Execution;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;

namespace Datos.Queries
{
    public class ProductoQuery :IProductoQuery
    {
        private readonly IDbConnection connection;
        private readonly Compiler sqlKataCompiler;

        public ProductoQuery(IDbConnection connection, Compiler sqlKataCompiler)
        {
            this.connection = connection;
            this.sqlKataCompiler = sqlKataCompiler;
        }

        public List<ProductoDTO> GetAllProductos()
        {
            var db = new QueryFactory(connection, sqlKataCompiler);
            var query = db.Query("Productos").Select( "Nombre", "Precio", "Marca", "Codigo").Get<ProductoDTO>().ToList();

            return query;
        }
    }
}
