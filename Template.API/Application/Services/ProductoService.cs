using Dominio.Commands;
using Dominio.Entities;
using Dominio.Queries;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;

namespace Application.Services
{
    public interface IProductoService
    {
        Producto createProducto(ProductoDTO producto);
        List<ProductoDTO> GetProductos();
    }
    public  class ProductoService : IEntidadService<Producto>
    {
        private readonly IRepositorio<Entidad> repositorio;
      
        public ProductoService(IRepositorio<Entidad> repositorio)
        {
            this.repositorio = repositorio;
            
        }

        public Entidad Actualizar(Producto entidad)
        {
            return repositorio.Actualizar(entidad);
        }

        public Entidad Agregar(Producto entidad)
        {
            return repositorio.Agregar(entidad);
        }

        public int Contar(Expression<Func<Producto, bool>> where)
        {
            throw new NotImplementedException();
        }

       

        public void Eliminar(int id)
        {
            throw new NotImplementedException();
        }

        public List<Entidad> GetProductos()
        {
            return repositorio.OptenerTodos();
        }

        public Entidad ObtenerPorId(int id)
        {
            throw new NotImplementedException();
        }

        public List<Entidad> OptenerTodos()
        {
            throw new NotImplementedException();
        }

        void IEntidadService<Producto>.Actualizar(Producto entidad)
        {
            throw new NotImplementedException();
        }
    }
}
