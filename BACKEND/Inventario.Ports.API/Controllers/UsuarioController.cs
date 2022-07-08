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
    public class UsuarioController : ControllerBase
    {

        public UsuariosUseCase CreateService() 
        {
            InventarioDB db = new InventarioDB();
            Usuariorepository repository = new Usuariorepository(db);
            UsuariosUseCase service = new UsuariosUseCase(repository);
            return service;
        }

        // GET: api/<UsuarioController>
        [HttpGet]
        public ActionResult<IEnumerable<Usuarios>> Get()
        {
            UsuariosUseCase service = CreateService();
            return Ok(service.GetAll());
        }

        // GET api/<UsuarioController>/5
        [HttpGet("{id}")]
        public ActionResult<Usuarios> Get(Guid id)
        {
            UsuariosUseCase service = CreateService();
            return Ok(service.GetById(id));
        }

        // POST api/<UsuarioController>
        [HttpPost]
        public ActionResult<Usuarios> Post([FromBody] Usuarios usuarios) 
        {
            UsuariosUseCase service = CreateService();
            var result = service.Create(usuarios);
            return Ok(result);
        }

        // PUT api/<UsuarioController>/5
        [HttpPut("{id}")]
        public ActionResult Put(Guid id, [FromBody] Usuarios usuarios)
        {
            UsuariosUseCase service = CreateService();
            usuarios.user_id = id;
            service.Update(usuarios);
            return Ok("Editado exitoso");
        }

        // DELETE api/<UsuarioController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(Guid id)
        {
            UsuariosUseCase service = CreateService();
            service.Delete(id);
            return Ok("Eliminado exitoso");
        }
    }
}
