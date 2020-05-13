
using CAPA_DOMINIO.DTOs;
using Dominio.Commands;
using Dominio.DTOs;
using Dominio.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Services
{
    public interface ICarritoProductoService
    {
        Carrito_Producto CreateCarritoProducto(Carrito_ProductoDTO carrito);
        Carrito_Producto DeleteCarritoProducto(Carrito_ProductoDTO carrito);
        Carrito_Producto UpdateCarrito(Carrito_ProductoDTO carrito);

        IEnumerable<Carrito_Producto> GetALL();
        Carrito_Producto GetByID(int id);

        Carrito_ProductoDTO CreateCarritoProducto(int Carrito,int Producto);


    }
   public class CarritoProductoService : ICarritoProductoService
    {
        private readonly IGenericsRepositoty _repository;

        public CarritoProductoService(IGenericsRepositoty repository)
        {
            _repository = repository;
        }

        public Carrito_Producto CreateCarritoProducto(Carrito_ProductoDTO carrito)
        {
            var entity = new Carrito_Producto()
            {
                //Carrito = carrito.Carrito,
                //Producto = carrito.Producto
            };
            _repository.Add<Carrito_Producto>(entity);
            return entity;
        }



        public Carrito_Producto DeleteCarritoProducto(Carrito_ProductoDTO carrito)
        {
            var entity = new Carrito_Producto()
            {
                //Id = carrito.Id,
                //Carrito = carrito.Carrito,
                //Producto = carrito.Producto
            };
            _repository.Delete<Carrito_Producto>(entity);
            return entity;
        }

        public IEnumerable<Carrito_Producto> GetALL()
        {
            var entity = _repository.GetALL<Carrito_Producto>();
            return entity;
        }

        public Carrito_Producto GetByID(int id)
        {
            return _repository.GetBy<Carrito_Producto>(id);
        }

        public Carrito_Producto UpdateCarrito(Carrito_ProductoDTO carrito)
        {
            var entity = new Carrito_Producto()
            {
                //Id= carrito.Id,
                //Carrito= carrito.Carrito,
                //Producto= carrito.Producto
            };
            _repository.Update<Carrito_Producto>(entity);
            return entity;
        }

        Carrito_ProductoDTO ICarritoProductoService.CreateCarritoProducto(int Carrito, int Producto)
        {
            throw new NotImplementedException();
        }
    }
}
