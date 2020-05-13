using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Services;
using Dominio.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Template.API2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Producto2Controller : ControllerBase
    {
        private readonly IEntidadService<Producto> _servise;

        public Producto2Controller(IEntidadService<Producto> service)
        {
            _servise = service;
        }
        [HttpPost]
        public IActionResult Post(Producto producto)
        {
            try
            {
                return new JsonResult(_servise.Agregar(producto)) { StatusCode = 201 };
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }
        [HttpGet]
        public IActionResult GetEntidades()
        {

            try
            {
                return new JsonResult(_servise.OptenerTodos()) { StatusCode = 200 };
            }
            catch (Exception e)
            {

                return BadRequest(e.Message); 
            }

        }
    }
}