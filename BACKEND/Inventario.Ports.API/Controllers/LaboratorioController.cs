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
    public class LaboratorioController : ControllerBase
    {
       
        public LaboratorioUseCase CreateService() 
        {
            InventarioDB db = new InventarioDB();
            Laboratoriorepository repository = new Laboratoriorepository(db);
            LaboratorioUseCase service = new LaboratorioUseCase(repository);
            return service;
        }

        // GET: api/<UsuarioController>
        [HttpGet]
        public ActionResult<IEnumerable<Laboratorios>> Get()
        {
            LaboratorioUseCase  service = CreateService();
            return Ok(service.GetAll());
        }

        // GET api/<UsuarioController>/5
        [HttpGet("{id}")]
        public ActionResult<Laboratorios> Get(Guid id)
        {
            LaboratorioUseCase  service = CreateService();
            return Ok(service.GetById(id));
        }

        // POST api/<UsuarioController>
        [HttpPost]
        public ActionResult<Laboratorios> Post([FromBody] Laboratorios laboratorios) 
        {
            LaboratorioUseCase  service = CreateService();
            var result = service.Create(laboratorios);
            return Ok(result);
        }

        // PUT api/<UsuarioController>/5
        [HttpPut("{id}")]
        public ActionResult Put(Guid id, [FromBody] Laboratorios laboratorios)
        {
            LaboratorioUseCase service = CreateService();
            laboratorios.lab_id = id;
            service.Update(laboratorios);
            return Ok("Editado exitoso");
        }

        // DELETE api/<UsuarioController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(Guid id)
        {
            LaboratorioUseCase service = CreateService();
            service.Delete(id);
            return Ok("Eliminado exitoso");
        }
    }
}
