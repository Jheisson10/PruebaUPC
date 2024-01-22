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
    public class DetMatriculasController : ControllerBase
    {
        private readonly ModelContext _context;

        public DetMatriculasController(ModelContext context)
        {
            _context = context;
        }

        // GET: api/DetMatriculas
        //[HttpGet]
        //public async Task<ActionResult<IEnumerable<DetMatricula>>> GetDetMatricula()
        //{
        //    return await _context.DetMatricula.ToListAsync();
        //}

        // GET: api/DetMatriculas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DetMatricula>> GetDetMatricula(long id)
        {
            var detMatricula = await _context.DetMatricula.FindAsync(id);

            if (detMatricula == null)
            {
                return NotFound();
            }

            return detMatricula;
        }

        [HttpGet]
        public async Task<ActionResult<DetMatricula>> DetMatricula([FromQuery] long idMatricula, string lineaCurso, string codCurso)
        {
            var detMatricula = await _context.DetMatricula.FindAsync(idMatricula, lineaCurso, codCurso);

            if (detMatricula == null)
            {
                return NotFound();
            }

            return detMatricula;
        }

        // PUT: api/DetMatriculas/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDetMatricula(long id, DetMatricula detMatricula)
        {
            if (id != detMatricula.MatriculaIdMatricula)
            {
                return BadRequest();
            }

            _context.Entry(detMatricula).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DetMatriculaExists(id))
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

        // POST: api/DetMatriculas
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<DetMatricula>> PostDetMatricula(DetMatricula detMatricula)
        {
            _context.DetMatricula.Add(detMatricula);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (DetMatriculaExists(detMatricula.MatriculaIdMatricula))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetDetMatricula", new { id = detMatricula.MatriculaIdMatricula }, detMatricula);
        }

        // DELETE: api/DetMatriculas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDetMatricula(long id)
        {
            var detMatricula = await _context.DetMatricula.FindAsync(id);
            if (detMatricula == null)
            {
                return NotFound();
            }

            _context.DetMatricula.Remove(detMatricula);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DetMatriculaExists(long id)
        {
            return _context.DetMatricula.Any(e => e.MatriculaIdMatricula == id);
        }
    }
}
