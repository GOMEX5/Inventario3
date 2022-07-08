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
    public class DiagnosticoController : ControllerBase
    {

        public DiagnosticoUseCase CreateService()
        {
            InventarioDB db = new InventarioDB();
            Diagnosticorepository repository = new Diagnosticorepository(db);
            DiagnosticoUseCase service = new DiagnosticoUseCase (repository);
            return service;
        }

        // GET: api/<UsuarioController>
        [HttpGet]
        public ActionResult<IEnumerable<Diagnostico_Pc>> Get()
        {
            DiagnosticoUseCase service = CreateService();
            return Ok(service.GetAll());
        }

        // GET api/<UsuarioController>/5
        [HttpGet("{id}")]
        public ActionResult<Diagnostico_Pc> Get(Guid id)
        {
            DiagnosticoUseCase service = CreateService();
            return Ok(service.GetById(id));
        }

        // POST api/<UsuarioController>
        [HttpPost]
        public ActionResult<Diagnostico_Pc> Post([FromBody] Diagnostico_Pc diagnostico_Pc)
        {
            DiagnosticoUseCase service = CreateService();
            var result = service.Create(diagnostico_Pc);
            return Ok(result);
        }

        // PUT api/<UsuarioController>/5
        [HttpPut("{id}")]
        public ActionResult Put(Guid id, [FromBody] Diagnostico_Pc diagnostico_Pc)
        {
            DiagnosticoUseCase  service = CreateService();
            diagnostico_Pc.diagnostico_pc_id = id;
            service.Update(diagnostico_Pc);
            return Ok("Editado exitoso");
        }

        // DELETE api/<UsuarioController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(Guid id)
        {
            DiagnosticoUseCase service = CreateService();
            service.Delete(id);
            return Ok("Eliminado exitoso");
        }
    }
}
