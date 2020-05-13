
using Dominio.DTOs;
using Dominio.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio.Queries
{
    public interface IClienteQuery
    {
        List<ClienteDTO> GetClientedni(string dni);
    }
}
