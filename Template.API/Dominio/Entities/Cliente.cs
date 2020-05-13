using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio.Entities
{
     public class Cliente : Entidad
    {
        //int id;
        //DateTime Fechadeactualizaion;
        
        string nombre;
        string apellido;
        string dni;
        string direccion;
        string telefono;
        //public int Id { get => id; set => id = value; }
        //public DateTime Fechadeactualizaion1 { get => Fechadeactualizaion; set => Fechadeactualizaion = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Apellido { get => apellido; set => apellido = value; }
        public string Dni { get => dni; set => dni = value; }
        public string Direccion { get => direccion; set => direccion = value; }
        public string Telefono { get => telefono; set => telefono = value; }
    }
}
