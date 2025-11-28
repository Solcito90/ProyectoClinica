using System.Collections.Generic;
using System.Linq;
using Clinica.Dominio.Entidades;
using Microsoft.AspNetCore.Mvc;

namespace Clinica.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MedicosController : ControllerBase
    {
        // Por ahora: lista en memoria (más adelante usamos la BD real)
        private static readonly List<Medico> _medicos = new()
        {
            new Medico { Id = 1, Nombre = "Juan Pérez", Especialidad = "Clínica", Matricula = "ABC123" },
            new Medico { Id = 2, Nombre = "Ana Gómez", Especialidad = "Pediatría", Matricula = "DEF456" }
        };

        // GET api/medicos
        [HttpGet]
        public ActionResult<IEnumerable<Medico>> Get()
        {
            return Ok(_medicos);
        }

        // GET api/medicos/1
        [HttpGet("{id:int}")]
        public ActionResult<Medico> GetById(int id)
        {
            var medico = _medicos.FirstOrDefault(m => m.Id == id);
            if (medico == null)
                return NotFound("Médico no encontrado");

            return Ok(medico);
        }

        // POST api/medicos
        [HttpPost]
        public ActionResult<Medico> Post(Medico nuevo)
        {
            nuevo.Id = _medicos.Any() ? _medicos.Max(m => m.Id) + 1 : 1;
            _medicos.Add(nuevo);

            return CreatedAtAction(nameof(GetById), new { id = nuevo.Id }, nuevo);
        }

        // PUT api/medicos/5
        [HttpPut("{id:int}")]
        public ActionResult Put(int id, Medico actualizado)
        {
            var medico = _medicos.FirstOrDefault(m => m.Id == id);
            if (medico == null)
                return NotFound("Médico no encontrado");

            medico.Nombre = actualizado.Nombre;
            medico.Especialidad = actualizado.Especialidad;
            medico.Matricula = actualizado.Matricula;

            return Ok(medico);
        }

        // DELETE api/medicos/5
        [HttpDelete("{id:int}")]
        public ActionResult Delete(int id)
        {
            var medico = _medicos.FirstOrDefault(m => m.Id == id);
            if (medico == null)
                return NotFound("Médico no encontrado");

            _medicos.Remove(medico);
            return NoContent();
        }
    }
}
