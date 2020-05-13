﻿using Dominio.DTOs;
using Dominio.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio.Queries
{
    public interface IProductoQuery
    {
        List<ProductoDTO> GetProductoCOD(string codigo);
    }
}
