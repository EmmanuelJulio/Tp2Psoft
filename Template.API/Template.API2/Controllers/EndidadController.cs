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
    public class EntidadController : ControllerBase
    {
        private readonly IEntidadService<Entidad> _servise;

        public EntidadController(IEntidadService<Entidad> service)
        {
            _servise = service;
        }

        [HttpPost]
        public IActionResult Post(Entidad producto)
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
        public List<Entidad> GetEntidades()
        {

            return _servise.OptenerTodos();
          
        }
    }
}