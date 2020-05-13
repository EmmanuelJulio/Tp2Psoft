
using Dominio.Commands;
using Dominio.DTOs;
using Dominio.Entities;
using Dominio.Queries;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;

namespace Application.Services
{
    public interface IVentaService
    {
        Venta CreateVentas(VentaDTO carrito);
        Venta DeleteVentas(VentaDTO carrito);
        Venta UpdateVentas(VentaDTO carrito);
        IEnumerable<Venta> GetALL();

        Venta GetByID(int id);
        List<VentaDTO> GetVentas();
        List<VentaReporteGETDtos> GetReportes();
        List<ListProductoVentas> GetProductoCodigo(string codigo);

        VentaPostDTOs CreateNuevaVenta(int carrito);

        


    }
    public class VentaService: IVentaService
    {
        private readonly IGenericsRepositoty _repository;
        private readonly IVentaQuery _query;
        public VentaService(IGenericsRepositoty repository ,IVentaQuery query)
        {
            _repository = repository;
            _query = query;
        }

       

        public Venta DeleteVentas(VentaDTO venta)
        {
            var entity = new Venta()
            {
                //Id = venta.Id,
                //Carrito = venta.Carrito,
                //Fecha = venta
            };
            _repository.Add<Venta>(entity);
            return entity;
        }

        public IEnumerable<Venta> GetALL()
        {
            return _repository.GetALL<Venta>();
        }

        public Venta GetByID(int id)
        {
            return _repository.GetBy<Venta>(id);
        }

        public Venta UpdateVentas(VentaDTO venta)
        {
            var entity = new Venta()
            {
                //Id = venta.Id,
                //Carrito = venta.Carrito,
                //Fecha = venta.Fecha
            };
            _repository.Add<Venta>(entity);
            return entity;
        }
        public List<VentaDTO> GetVentas()
        {
            return _query.GetAllVentas();
        }

       
        public List<VentaReporteGETDtos> GetReportes()
        {
            return _query.GetReportes();
        }

        public List<ListProductoVentas> GetProductoCodigo(string codigo)
        {
            
            int contador = 0;    
            foreach (var item in GetReportes())
            {
                if(item.ProductoCodigo == codigo)
                {
                    contador++;
                }
            }
             var result = GetReportes().First(s => s.ProductoCodigo == codigo);
            var Entity = new ListProductoVentas()
            {
                Cliente_id = result.ClienteID,
                Producto_id = result.ProductoID,
                Producto_Codigo = result.ProductoCodigo,
                Producto_Marca = result.ProductoMarca,
                Producto_Precio = result.ProductPrecio,
                Cantidad = contador 
            };
            List<ListProductoVentas> listnew = new List<ListProductoVentas>();
            listnew.Add(Entity);
            return listnew.ToList();
            
            
            

          

           
        }

       

        public Venta CreateVentas(VentaDTO carrito)
        {
            throw new NotImplementedException();
        }

        public VentaPostDTOs CreateNuevaVenta(int carrito)
        {
            throw new NotImplementedException();
        }
    }
}
