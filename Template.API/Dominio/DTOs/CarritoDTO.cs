
using Dominio.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Dominio.DTOs
{
    public class CarritoDTO 
    {
        public int Clienteid { get; set; }
        public virtual Cliente Cliente { get; set; }
    }
}
