
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Dominio.Entities
{
    public class Carrito : Entidad
    {
        
        public int Clienteid { get; set; }
        public virtual Cliente Cliente { get; set; }

      
    }
}
