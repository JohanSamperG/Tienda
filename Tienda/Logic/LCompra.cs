using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tienda.Models;

namespace Tienda.Logic
{
    public class LCompra : ControllerBase
    {
        private readonly TiendaContext _context;
        public LCompra(TiendaContext context)
        {
            _context = context;
        }
        //Metodo que retorna una lista de Tcompra [GET]
        public async Task<ActionResult<IEnumerable<Tcompra>>> GetCompra()
        {
            return await _context.Tcompra.ToListAsync();
        }

        //Metodo que retorna un Tcompra por id [GET]
        public async Task<ActionResult<Tcompra>> GetCompraById(int id)
        {
            var tcompra = await _context.Tcompra.FindAsync(id);

            if (tcompra == null)
            {
                return NotFound();
            }

            return tcompra;
        }

        //Metodo que actualiza un Tcompra [PUT]
        public async Task<IActionResult> PutCompra(int id, Tcompra tcompra)
        {
            if (id != tcompra.IdCompra)
            {
                return BadRequest();
            }

            _context.Entry(tcompra).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TcompraExists(id))
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

        //Metodo que registra un Tcompra [POST]
        public async Task<ActionResult<Tcompra>> PostCompra(Tcompra tcompra)
        {
            _context.Tcompra.Add(tcompra);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTcompra", new { id = tcompra.IdCompra }, tcompra);
        }

        //Metodo que registra un Tcompra [DELETE]
        public async Task<ActionResult<Tcompra>> DeleteCompra(int id)
        {
            var tcompra = await _context.Tcompra.FindAsync(id);
            if (tcompra == null)
            {
                return NotFound();
            }

            _context.Tcompra.Remove(tcompra);
            await _context.SaveChangesAsync();

            return tcompra;
        }


        //Metodo encargado de validar que el registro exista
        private bool TcompraExists(int id)
        {
            return _context.Tcompra.Any(e => e.IdCompra == id);
        }
    }
}
