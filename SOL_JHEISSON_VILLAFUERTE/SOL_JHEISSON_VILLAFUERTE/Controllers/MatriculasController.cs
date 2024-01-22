using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SOL_JHEISSON_VILLAFUERTE.Models;

namespace SOL_JHEISSON_VILLAFUERTE.Controllers
{
    [Route("v2/[controller]")]
    [ApiController]
    public class MatriculasController : ControllerBase
    {
        private readonly ModelContext _context;

        public MatriculasController(ModelContext context)
        {
            _context = context;
        }

        // GET: api/Matriculas
        //[HttpGet]
        //public async Task<ActionResult<IEnumerable<Matricula>>> GetMatricula()
        //{
        //    return await _context.Matricula.ToListAsync();
        //}

        // GET: api/Matriculas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Matricula>> GetMatricula(long id)
        {
            var matricula = await _context.Matricula.FindAsync(id);

            if (matricula == null)
            {
                return NotFound();
            }

            return matricula;
        }

        [HttpGet]
        public async Task<ActionResult<Matricula>> Matricula([FromQuery] long idMatricula)
        {
            var matricula = await _context.Matricula.FindAsync(idMatricula);

            if (matricula == null)
            {
                return NotFound();
            }

            return matricula;
        }

        // PUT: api/Matriculas/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMatricula(long id, Matricula matricula)
        {
            if (id != matricula.IdMatricula)
            {
                return BadRequest();
            }

            _context.Entry(matricula).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MatriculaExists(id))
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

        // POST: api/Matriculas
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Matricula>> PostMatricula(Matricula matricula)
        {
            _context.Matricula.Add(matricula);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (MatriculaExists(matricula.IdMatricula))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetMatricula", new { id = matricula.IdMatricula }, matricula);
        }

        // DELETE: api/Matriculas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMatricula(long id)
        {
            var matricula = await _context.Matricula.FindAsync(id);
            if (matricula == null)
            {
                return NotFound();
            }

            _context.Matricula.Remove(matricula);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool MatriculaExists(long id)
        {
            return _context.Matricula.Any(e => e.IdMatricula == id);
        }
    }
}
