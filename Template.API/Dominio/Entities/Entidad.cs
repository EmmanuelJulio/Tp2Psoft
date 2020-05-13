using System;

namespace Dominio.Entities
{
    public class Entidad
    {
        public int id { get; set; }
        private DateTime fechaIncercion { get; set; }

        public int Id { get => id; set => id = value; }
        public DateTime FechaIncercion { get => fechaIncercion; set => fechaIncercion = value; }
    }
}
