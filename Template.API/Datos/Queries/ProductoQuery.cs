using Dominio.DTOs;
using Dominio.Queries;
using SqlKata.Compilers;
using SqlKata.Execution;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace CAPA_DATO.Queries
{
    public class ProductoQuery : IProductoQuery
    {
        private readonly IDbConnection connection;
        private readonly Compiler compiler;

        public ProductoQuery(IDbConnection connection, Compiler compiler)
        {
            this.connection = connection;
            this.compiler = compiler;
        }

        public List<ProductoDTO> GetProductoCOD(string codigo)
        {
            var db = new QueryFactory(connection, compiler);
            var result = db.Query("Product").WhereLike("codigo", $"%{codigo}%").Get<ProductoDTO>().ToList();
            return result;
        }
    }
}
