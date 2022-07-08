using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Inventario.Adoptors.SQLServerDataAccess.Contexts;
using Inventario.Core.Application.UseCases;
using Inventario.Core.Infraestructure.Repository.Concrete;
using Inventario.Core.Domain.Models;
using System.Collections.Generic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Inventario.Ports.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HerramientasController : ControllerBase
    {

        public HerramientasUseCase CreateService()
        {
            InventarioDB db = new InventarioDB();
            Herramientasrepository repository = new Herramientasrepository(db);
            HerramientasUseCase service = new HerramientasUseCase(repository);
            return service;
        }

        // GET: api/<UsuarioController>
        [HttpGet]
        public ActionResult<IEnumerable<Herramientas>> Get()
        {
            HerramientasUseCase service = CreateService();
            return Ok(service.GetAll());
        }

        // GET api/<UsuarioController>/5
        [HttpGet("{id}")]
        public ActionResult<Herramientas> Get(Guid id)
        {
            HerramientasUseCase service = CreateService();
            return Ok(service.GetById(id));
        }

        // POST api/<UsuarioController>
        [HttpPost]
        public ActionResult<Laboratorios> Post([FromBody] Herramientas herramientas)
        {
            HerramientasUseCase service = CreateService();
            var result = service.Create(herramientas);
            return Ok(result);
        }

        // PUT api/<UsuarioController>/5
        [HttpPut("{id}")]
        public ActionResult Put(Guid id, [FromBody] Herramientas herramientas)
        {
            HerramientasUseCase service = CreateService();
            herramientas.herramienta_id = id;
            service.Update(herramientas);
            return Ok("Editado exitoso");
        }

        // DELETE api/<UsuarioController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(Guid id)
        {
            HerramientasUseCase service = CreateService();
            service.Delete(id);
            return Ok("Eliminado exitoso");
        }
    }
}

