
using Dominio.Commands;
using Dominio.DTOs;
using Dominio.Entities;
using Dominio.Queries;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Services
{

    public interface IProductoServices
    {
        Producto CreateProducto(ProductoDTO producto);
        Producto DeleteProducto(ProductoDTO producto);
        Producto UpdateProducto(ProductoDTO producto);
        IEnumerable<Producto> GetALL();
        Producto GetByID (int id);
        List<ProductoDTO> GetProductos();
        List<ProductoDTO> GetProductoCodigo(string codigo);




    }
   public class ProductoServices :IProductoServices
    {
        private readonly IGenericsRepositoty _repository;
        private readonly IProductoQuery _query;
        public ProductoServices(IGenericsRepositoty repository, IProductoQuery query)
        {
            _repository = repository;
            _query = query;
            
        }

        public Producto CreateProducto(ProductoDTO producto)
        {
            throw new NotImplementedException();
        }

        public Producto DeleteProducto(ProductoDTO producto)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Producto> GetALL()
        {
            var entity = _repository.GetALL<Producto>();
            return entity;
        }

        public Producto GetByID(int id)
        {
            return _repository.GetBy<Producto>(id);
        }

        public List<ProductoDTO> GetProductoCodigo(string codigo)
        {
            return _query.GetProductoCOD(codigo);
        }

        public List<ProductoDTO> GetProductos()
        {
            throw new NotImplementedException();
        }

        public Producto UpdateProducto(ProductoDTO producto)
        {
            throw new NotImplementedException();
        }
    }
}
