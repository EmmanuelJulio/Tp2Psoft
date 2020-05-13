
using Dominio.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio.DTOs
{
    public class Carrito_ProductoDTO 
    {
       public int productoID { get; set; }
        public int carritoID { get; set; }

        public virtual Producto Producto { get; set; }
        public virtual Carrito Carrito { get; set; }
    }
}
