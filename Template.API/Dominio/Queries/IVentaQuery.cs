using Dominio.DTOs;
using Dominio.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio.Queries
{
    public interface IVentaQuery
    {
        List<VentaDTO> GetAllVentas();
        
        List<VentaReporteGETDtos> GetReportes();

        List<ListProductoVentas> GetProductoCOD(string codigo);

        
    }
}
