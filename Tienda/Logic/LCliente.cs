using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tienda.Models;

namespace Tienda.Logic
{
    public class LCliente : ControllerBase
    {
        private readonly TiendaContext _context;
        public LCliente(TiendaContext context)
        {
            _context = context;
        }

        //Metodo que retorna una lista de Tcliente [GET]
        public async Task<ActionResult<IEnumerable<Tcliente>>> GetCliente()
        {
            return await _context.Tcliente.ToListAsync();
        }

        //Metodo que retorna un Tcliente especifico [GET]
        public async Task<ActionResult<Tcliente>> GetClienteById(int id)
        {
            var tcliente = await _context.Tcliente.FindAsync(id);

            if (tcliente == null)
            {
                return NotFound();
            }

            return tcliente;
        }

        //Metodo que actualiza la iformacion de un Tcliente [PUT]
        public async Task<IActionResult> PutCliente(int id, Tcliente tcliente)
        {
            if (id != tcliente.IdCliente)
            {
                return BadRequest();
            }

            _context.Entry(tcliente).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TclienteExists(id))
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

        //Metodo que registra la iformacion de un Tcliente [POST]
        public async Task<ActionResult<Tcliente>> PostCliente(Tcliente tcliente)
        {
            _context.Tcliente.Add(tcliente);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTcliente", new { id = tcliente.IdCliente }, tcliente);
        }

        public async Task<ActionResult<Tcliente>> DeleteCliente(int id)
        {
            var tcliente = await _context.Tcliente.FindAsync(id);
            if (tcliente == null)
            {
                return NotFound();
            }

            _context.Tcliente.Remove(tcliente);
            await _context.SaveChangesAsync();

            return tcliente;
        }

        private bool TclienteExists(int id)
        {
            return _context.Tcliente.Any(e => e.IdCliente == id);
        }
    }
}
