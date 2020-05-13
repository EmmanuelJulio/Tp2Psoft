using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Dominio.Entities
{
    public class Producto : Entidad
    {
        
        string codigo;
        string marca;
        string nombre;
        [Column(TypeName = "decimal(15,2)")]
        decimal precio { get; set; }
        public string Codigo { get => codigo; set => codigo = value; }
        public string Marca { get => marca; set => marca = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        
      
    }
}
