
using Dominio.Commands;
using Dominio.DTOs;
using Dominio.Entities;
using Dominio.Queries;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Services
{
    public interface IClienteService
    {
        Cliente CreateCliente(ClienteDTO cliente);
        Cliente DeleteCliente(ClienteDTO cliente);
        Cliente UpdateCliente(ClienteDTO cliente);
        IEnumerable<Cliente> GetALL();
        Cliente GetByID(int id);
        List<ClienteDTO> GetCliente(string dni);




    }
    public class ClienteService :IClienteService
    {
        private readonly IGenericsRepositoty _repository;
        private readonly IClienteQuery _query;

        public ClienteService(IGenericsRepositoty repositorio, IClienteQuery query)
        {
            _repository = repositorio;
            _query = query;
        }

        public Cliente CreateCliente(ClienteDTO cliente)
        {
            var entity = new Cliente()
            {
                Dni = cliente.Dni,
                Nombre = cliente.Nombre,
                Apellido = cliente.Apellido,
                Direccion = cliente.Direccion,
                Telefono = cliente.Telefono
            };
            _repository.Add<Cliente>(entity);
            return entity;
        }


        public Cliente DeleteCliente(ClienteDTO cliente)
        {
            var entity = new Cliente()
            {
                //Id = cliente.Id,
                //Dni = cliente.Dni,
                //Nombre = cliente.Nombre,
                //Apellido = cliente.Apellido,
                //Direccion = cliente.Direccion,
                //Telefono = cliente.Telefono
            };
            _repository.Delete<Cliente>(entity);
            return entity;
        }

        public IEnumerable<Cliente> GetALL()
        {
            var entity = _repository.GetALL<Cliente>();
            return entity;
        }

        public Cliente GetByID(int id)
        {
            return _repository.GetBy<Cliente>(id);
        }

        public List<ClienteDTO> GetCliente(string dni)
        {
            return _query.GetClientedni(dni);
        }

        public Cliente UpdateCliente(ClienteDTO cliente)
        {
            var entity = new Cliente()
            {
                //Id = cliente.Id,
                //Dni = cliente.Dni,
                //Nombre = cliente.Nombre,
                //Apellido = cliente.Apellido,
                //Direccion = cliente.Direccion,
                //Telefono = cliente.Telefono
            };
            _repository.Update<Cliente>(entity);
            return entity;
        }
    }
}
