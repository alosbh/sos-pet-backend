using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ApiSOSPet;
using Microsoft.AspNetCore.Routing.Template;
using System.Collections;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.EntityFrameworkCore.Query.Internal;

namespace ApiSOSPet.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OcorrenciasController : ControllerBase
    {
        private readonly SospetContext _context;

        public OcorrenciasController()
        {
            _context = new SospetContext();
        }

        //// GET: api/Ocorrencias
        //[HttpGet]
        //public IActionResult Get()
        //{
        //    /*return await _context.Ocorrencias.ToListAsync();*/
        //    var query = _context.Ocorrencias
        //            .Join(
        //            _context.Animais,
        //            ocorrencia => ocorrencia.Idanimal,
        //            animal => animal.Id,
        //            (ocorrencia, animal) => new { animal.Especie, animal.Porte, animal.Raca, ocorrencia.Descricao, ocorrencia.Idocorr, ocorrencia.latitude, ocorrencia.longitude }).ToList();

        //    return Ok(query);

        //}

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Ocorrencia>>> GetOcorrencias()
        {
            
            return await _context.Ocorrencias.ToListAsync();
        }

        // GET: api/Ocorrencias/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Ocorrencia>> GetOcorrencia(long id)
        {
            var ocorrencia = await _context.Ocorrencias.FindAsync(id);

            if (ocorrencia == null)
            {
                return NotFound();
            }

            return ocorrencia;
        }

        // GET: api/Ocorrencias/usuario=1
        [HttpGet("usuario={id}")]
        public async Task<ActionResult<IEnumerable<Ocorrencia>>> GetOcorrencia(long? id)
        {

            var ocorrencia = await _context.Ocorrencias.ToListAsync();
            var ocorrencia2 = _context.Ocorrencias.ToList();
    
            if (ocorrencia == null)
            {
                return NotFound();
            }

            ocorrencia2.Clear();
            

            foreach (var item in ocorrencia)
            {

                if (item.Idusuario == id)
                {
                    ocorrencia2.Add(item);
                }
                    
            }
            return ocorrencia2;
        }
        // PUT: api/Ocorrencias/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOcorrencia(long id, Ocorrencia ocorrencia)
        {
            if (id != ocorrencia.Idocorr)
            {
                return BadRequest();
            }

            _context.Entry(ocorrencia).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OcorrenciaExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Ocorrencias
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Ocorrencia>> PostOcorrencia(Ocorrencia ocorrencia)
        {
            
            _context.Ocorrencias.Add(ocorrencia);
            
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetOcorrencia", new { id = ocorrencia.Idocorr }, ocorrencia);
        }

        // DELETE: api/Ocorrencias/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Ocorrencia>> DeleteOcorrencia(long id)
        {
            var ocorrencia = await _context.Ocorrencias.FindAsync(id);
            if (ocorrencia == null)
            {
                return NotFound();
            }

            _context.Ocorrencias.Remove(ocorrencia);
            await _context.SaveChangesAsync();

            return ocorrencia;
        }

        private bool OcorrenciaExists(long id)
        {
            return _context.Ocorrencias.Any(e => e.Idocorr == id);
        }
    }
}
