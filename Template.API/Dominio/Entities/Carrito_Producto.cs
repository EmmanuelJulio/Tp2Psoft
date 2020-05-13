
using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio.Entities
{
    public class Carrito_Producto : Entidad
    {
        
       public int productoID { get; set; }
        public int carritoID { get; set; }

        public virtual Producto Productos { get; set; }
        public virtual Carrito Carrito { get; set; }
    }
}
