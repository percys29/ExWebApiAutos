using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ExWebApiAutos.Model.Repositories;
using ExWebApiAutos.Model.VehiculoDb;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ExWebApiAutos.Controllers
{
    [Route("api/[controller]")]
    public class ProyectoController : Controller
    {
        private IProyectoRepository repositorio;
        public ProyectoController(IProyectoRepository repo)
        {
            repositorio = repo;
        }
        // GET: api/<controller>
        [HttpGet]
        public IQueryable<TMarca> Get()
        {
            return repositorio.Marcas;
        }
        // GET api/<controller>/5
        [HttpGet("{ProyectoId}")]
        public TMarca Get(Guid MarcaId)
        {
            return repositorio.Marcas.Where(p => p.MarcaId == MarcaId).FirstOrDefault();
        }
        // POST api/<controller>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]TMarca marca)
        {
            await repositorio.SaveProject(marca);
            return Ok(true);
        }
        // PUT api/<controller>/5
        [HttpPut("{ProyectoId}")]
        public async Task<IActionResult> Put(Guid MarcaId, [FromBody]TMarca marca)
        {
            marca.MarcaId = MarcaId;
            await repositorio.SaveProject(marca);
            return Ok(true);
        }
        // DELETE api/<controller>/5
        [HttpDelete("{ProyectoId}")]
        public IActionResult Delete(Guid MarcaId)
        {
            repositorio.DeleteProyecto(MarcaId);
            return Ok(true);
        }
    }
}
