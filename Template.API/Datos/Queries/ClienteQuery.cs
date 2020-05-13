using Dominio.DTOs;
using Dominio.Queries;
using SqlKata.Compilers;
using SqlKata.Execution;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Datos.Queries
{
    public class ClienteQuery : IClienteQuery
    {
        private readonly IDbConnection connection;
        private readonly Compiler compiler;

        public ClienteQuery(IDbConnection connection, Compiler compiler)
        {
            this.connection = connection;
            this.compiler = compiler;
        }

        public List<ClienteDTO> GetClientedni(string dni)
        {
            var db = new QueryFactory(connection, compiler);
            var query = db.Query("Client").WhereLike("dni", $"%{dni}%");
            var result = query.Get<ClienteDTO>();
            return result.ToList();
        }
    }
}
