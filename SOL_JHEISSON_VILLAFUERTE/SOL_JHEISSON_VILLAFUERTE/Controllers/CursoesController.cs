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
    public class CursoesController : ControllerBase
    {
        private readonly ModelContext _context;

        public CursoesController(ModelContext context)
        {
            _context = context;
        }

        // GET: api/Cursoes
        //HttpGet]
        //public async Task<ActionResult<IEnumerable<Curso>>> GetCurso()
        //{
        //    return await _context.Curso.ToListAsync();
        //}

        // GET: api/Cursoes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Curso>> GetCurso(string id)
        {
            var curso = await _context.Curso.FindAsync(id);

            if (curso == null)
            {
                return NotFound();
            }

            return curso;
        }

        [HttpGet]
        public async Task<ActionResult<Curso>> Curso([FromQuery] string codLineaNegocio, string codCurso)
        {
            var curso = await _context.Curso.FindAsync(codLineaNegocio, codCurso);

            if (curso == null)
            {
                return NotFound();
            }

            return curso;
        }

        // PUT: api/Cursoes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCurso(string id, Curso curso)
        {
            if (id != curso.CodLineaNegocio)
            {
                return BadRequest();
            }

            _context.Entry(curso).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CursoExists(id))
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

        // POST: api/Cursoes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Curso>> PostCurso(Curso curso)
        {
            _context.Curso.Add(curso);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (CursoExists(curso.CodLineaNegocio))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetCurso", new { id = curso.CodLineaNegocio }, curso);
        }

        // DELETE: api/Cursoes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCurso(string id)
        {
            var curso = await _context.Curso.FindAsync(id);
            if (curso == null)
            {
                return NotFound();
            }

            _context.Curso.Remove(curso);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CursoExists(string id)
        {
            return _context.Curso.Any(e => e.CodLineaNegocio == id);
        }
    }
}
