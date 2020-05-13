using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio.DTOs
{
    public class ResponseProductoById
    {
        public int id { get; set; }
        string codigo { get; set; }
        string marca { get; set; }
        string nombre { get; set; }
        decimal precio { get; set; }
    }
}
