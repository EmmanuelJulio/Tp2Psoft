using System;
using System.Net.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Dominio.Entities;

namespace Datos
{
    public class ContextApplication : DbContext
    {
        public ContextApplication(DbContextOptions<ContextApplication> options) : base (options)
        {

        }
        private DbSet<Producto> productos;
        private DbSet<Cliente> clientes;
        private DbSet<Carrito> carritos;
        private DbSet<Carrito_Producto> carritoProductos;
        private DbSet<Venta> ventas;

        public DbSet<Producto> Productos { get => productos; set => productos = value; }
        public DbSet<Cliente> Clientes { get => clientes; set => clientes = value; }
        public DbSet<Carrito> Carritos { get => carritos; set => carritos = value; }
        public DbSet<Carrito_Producto> CarritoProductos { get => carritoProductos; set => carritoProductos = value; }
        public DbSet<Venta> Ventas { get => ventas; set => ventas = value; }
    }
}
