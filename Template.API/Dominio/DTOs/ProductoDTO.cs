using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio.DTOs
{
    public class ProductoDTO
    {

        string codigo;
        string marca;
        string nombre;
        decimal precio;
       
       
        public string Codigo { get => codigo; set => codigo = value; }
        public string Marca { get => marca; set => marca = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public decimal Precio { get => precio; set => precio = value; }
      
    }
}
