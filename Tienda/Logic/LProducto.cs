using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tienda.Models;

namespace Tienda.Logic
{
    public class LProducto : ControllerBase
    {
        private readonly TiendaContext _context;
        public LProducto(TiendaContext context)
        {
            _context = context;
        }
        public async Task<ActionResult<IEnumerable<Tproducto>>> GetProducto()
        {
            return await _context.Tproducto.ToListAsync();
        }

        //Metodo que retorna un Tproducto por id [GET]
        public async Task<ActionResult<Tproducto>> GetProductoById(int id)
        {
            var tproducto = await _context.Tproducto.FindAsync(id);

            if (tproducto == null)
            {
                return NotFound();
            }

            return tproducto;
        }

        //Metodo que actualiza un Tproducto [PUT]
        public async Task<IActionResult> PutProducto(int id, Tproducto tproducto)
        {
            if (id != tproducto.IdProdcuto)
            {
                return BadRequest();
            }

            _context.Entry(tproducto).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TproductoExists(id))
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

        //Metodo que registra un Tproducto [POST]
        public async Task<ActionResult<Tproducto>> PostProducto(Tproducto tproducto)
        {
            _context.Tproducto.Add(tproducto);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTproducto", new { id = tproducto.IdProdcuto }, tproducto);
        }

        //Metodo que registra un Tproducto [DELETE]
        public async Task<ActionResult<Tproducto>> DeleteProducto(int id)
        {
            var tproducto = await _context.Tproducto.FindAsync(id);
            if (tproducto == null)
            {
                return NotFound();
            }

            _context.Tproducto.Remove(tproducto);
            await _context.SaveChangesAsync();

            return tproducto;
        }


        //Metodo encargado de validar que el registro exista
        private bool TproductoExists(int id)
        {
            return _context.Tproducto.Any(e => e.IdProdcuto == id);
        }
    }
}
