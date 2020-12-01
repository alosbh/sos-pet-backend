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

        // GET: api/Ocorrencias
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
        




        // GET: api/Ocorrencias/status=
        [HttpGet("status={id}")]
        public async Task<string> GetOcorrencia(string id)
        {

            var ocorrencia = await _context.Ocorrencias.ToListAsync();
            var ocorrencia2 = _context.Ocorrencias.ToList();

            if (ocorrencia == null)
            {
                Microsoft.AspNetCore.Mvc.NotFoundResult notFoundResult = new Microsoft.AspNetCore.Mvc.NotFoundResult();
                return notFoundResult.ToString();
            }

            ocorrencia2.Clear();
            int total = 0;

            foreach (var item in ocorrencia)
            {

                if (item.Status.ToLower() == id)
                {
                    total++;
                }

            }

            return "{" + "total" + '"' + ":" + '"' + total + '"' + "}";
        }

        
        private bool OcorrenciaExists(long id)
        {
            return _context.Ocorrencias.Any(e => e.Idocorr == id);
        }
    }
}
