using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio.Entities
{
    public class Venta : Entidad
    {
        
        public int carritoId { get; set; }
        public virtual Carrito CarritoNavigator { get; set; }
    }
}
