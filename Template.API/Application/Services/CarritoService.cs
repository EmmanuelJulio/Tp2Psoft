using Dominio.DTOs;
using Dominio.Commands;
using Dominio.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Services
{
    public interface ICarritoService
    {
        Carrito CreateCarrito(CarritoDTO carrito);
        Carrito DeleteCarrito(CarritoDTO carrito);
        Carrito UpdateCarrito(CarritoDTO carrito);
        IEnumerable<Carrito> GetALL();

        Carrito GetByID(int id);

        CarritoPostDTOs CreateNuevoCarrito(int cliente);

    }
    public class CarritoService : ICarritoService
    {
        private readonly IGenericsRepositoty _repository;
        public CarritoService(IGenericsRepositoty repositorio)
        {
            _repository = repositorio;
        }

        public Carrito CreateCarrito(CarritoDTO carrito)
        {
            var entity = new Carrito()
            {
                Cliente = carrito.Cliente
            };
            _repository.Add<Carrito>(entity);
            return entity;
        }

        public CarritoPostDTOs CreateNuevoCarrito(int cliente)
        {
            throw new NotImplementedException();
        }

        public Carrito DeleteCarrito(CarritoDTO carrito)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Carrito> GetALL()
        {
            var entity = _repository.GetALL<Carrito>();
            return entity;
        }

        public Carrito GetByID(int id)
        {
            return _repository.GetBy<Carrito>(id);
        }



        public Carrito UpdateCarrito(CarritoDTO carrito)
        {
            var entity = new Carrito()
            {
                //Id = carrito.Id,
                //Cliente = carrito.Cliente
            };
            _repository.Update<Carrito>(entity);
            return entity;
        }
    }
}
