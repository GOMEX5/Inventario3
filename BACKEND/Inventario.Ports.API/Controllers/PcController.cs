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
    public class PcController : ControllerBase
    {

        public PcUseCase CreateService()
        {
            InventarioDB db = new InventarioDB();
            Pcrepository repository = new Pcrepository(db);
            PcUseCase service = new PcUseCase(repository);
            return service;
        }

        // GET: api/<UsuarioController>
        [HttpGet]
        public ActionResult<IEnumerable<Pc>> Get()
        {
            PcUseCase service = CreateService();
            return Ok(service.GetAll());
        }

        // GET api/<UsuarioController>/5
        [HttpGet("{id}")]
        public ActionResult<Pc> Get(Guid id)
        {
            PcUseCase service = CreateService();
            return Ok(service.GetById(id));
        }

        // POST api/<UsuarioController>
        [HttpPost]
        public ActionResult<Pc> Post([FromBody] Pc pc)
        {
            PcUseCase service = CreateService();
            var result = service.Create(pc);
            return Ok(result);
        }

        // PUT api/<UsuarioController>/5
        [HttpPut("{id}")]
        public ActionResult Put(Guid id, [FromBody] Pc pc)
        {
            PcUseCase service = CreateService();
            pc.pc_id= id;
            service.Update(pc);
            return Ok("Editado exitoso");
        }

        // DELETE api/<UsuarioController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(Guid id)
        {
            PcUseCase service = CreateService();
            service.Delete(id);
            return Ok("Eliminado exitoso");
        }
    }
}
