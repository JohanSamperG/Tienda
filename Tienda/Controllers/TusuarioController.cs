using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Tienda.Models;

namespace Tienda.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TusuarioController : ControllerBase
    {
        private readonly TiendaContext _context;

        public TusuarioController(TiendaContext context)
        {
            _context = context;
        }

        // GET: api/Tusuario
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Tusuario>>> GetTusuario()
        {
            return await _context.Tusuario.ToListAsync();
        }

        // GET: api/Tusuario/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Tusuario>> GetTusuario(int id)
        {
            var tusuario = await _context.Tusuario.FindAsync(id);

            if (tusuario == null)
            {
                return NotFound();
            }

            return tusuario;
        }

        // PUT: api/Tusuario/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTusuario(int id, Tusuario tusuario)
        {
            if (id != tusuario.IdUsuario)
            {
                return BadRequest();
            }

            _context.Entry(tusuario).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TusuarioExists(id))
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

        // POST: api/Tusuario
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Tusuario>> PostTusuario(Tusuario tusuario)
        {
            _context.Tusuario.Add(tusuario);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTusuario", new { id = tusuario.IdUsuario }, tusuario);
        }

        // DELETE: api/Tusuario/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Tusuario>> DeleteTusuario(int id)
        {
            var tusuario = await _context.Tusuario.FindAsync(id);
            if (tusuario == null)
            {
                return NotFound();
            }

            _context.Tusuario.Remove(tusuario);
            await _context.SaveChangesAsync();

            return tusuario;
        }

        private bool TusuarioExists(int id)
        {
            return _context.Tusuario.Any(e => e.IdUsuario == id);
        }
    }
}
