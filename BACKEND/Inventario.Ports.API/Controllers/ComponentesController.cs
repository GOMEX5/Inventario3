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
    public class ComponentesController : ControllerBase
    {

        public ComponentesUseCase CreateService()
        {
            InventarioDB db = new InventarioDB();
            Componentesrepository repository = new Componentesrepository(db);
            ComponentesUseCase service = new ComponentesUseCase(repository);
            return service;
        }

        // GET: api/<UsuarioController>
        [HttpGet]
        public ActionResult<IEnumerable<Usuarios>> Get()
        {
            ComponentesUseCase service = CreateService();
            return Ok(service.GetAll());
        }

        // GET api/<UsuarioController>/5
        [HttpGet("{id}")]
        public ActionResult<Componentes> Get(Guid id)
        {
            ComponentesUseCase service = CreateService();
            return Ok(service.GetById(id));
        }

        // POST api/<UsuarioController>
        [HttpPost]
        public ActionResult<Componentes> Post([FromBody] Componentes componentes)
        {
            ComponentesUseCase service = CreateService();
            var result = service.Create(componentes);
            return Ok(result);
        }

        // PUT api/<UsuarioController>/5
        [HttpPut("{id}")]
        public ActionResult Put(Guid id, [FromBody] Componentes componentes)
        {
            ComponentesUseCase service = CreateService();
            componentes.componenete_id = id;
            service.Update(componentes);
            return Ok("Editado exitoso");
        }

        // DELETE api/<UsuarioController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(Guid id)
        {
            ComponentesUseCase service = CreateService();
            service.Delete(id);
            return Ok("Eliminado exitoso");
        }
    }
}
