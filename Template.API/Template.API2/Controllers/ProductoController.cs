using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Application.Services;
using Dominio.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Template.API2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductoController : ControllerBase
    {
        private readonly IProductoService _servise;
        public ProductoController(IProductoService service)
        {
            _servise = service;
        }
        [HttpPost]
        public IActionResult Post(ProductoDTO producto)
        {
            try
            {
                return new JsonResult( _servise.createProducto(producto)) { StatusCode=201 };
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }

        [HttpGet]
        public List<ProductoDTO> GetProductos()
        {
    
                return _servise.GetProductos();
          
        }
    }
}