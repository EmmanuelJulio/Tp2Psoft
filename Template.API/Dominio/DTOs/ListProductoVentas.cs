using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio.DTOs
{
    public class ListProductoVentas
    {

        public int Cliente_id { get; set; }
        
        public int Producto_id { get; set; }
        public string Producto_Codigo { get; set; }
        public string Producto_Marca { get; set; }
        public decimal Producto_Precio { get; set; }
        public int Cantidad { get; set; }

    }
}
