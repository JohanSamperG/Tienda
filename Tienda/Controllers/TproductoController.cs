using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Tienda.Models;
using lp = Tienda.Logic.LProducto;

namespace Tienda.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TproductoController : ControllerBase
    {
        private readonly TiendaContext _context;
        private lp _lproducto;
        public TproductoController(TiendaContext context)
        {
            _context = context;
            _lproducto = new lp(context);
        }

        // GET: api/Tproducto
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Tproducto>>> GetTproducto()
        {
            return await _lproducto.GetProducto();
        }

        // GET: api/Tproducto/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Tproducto>> GetTproducto(int id)
        {
            return await _lproducto.GetProductoById(id);
        }

        // PUT: api/Tproducto/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTproducto(int id, Tproducto tproducto)
        {
            return await _lproducto.PutProducto(id, tproducto);
        }

        // POST: api/Tproducto
        [HttpPost]
        public async Task<ActionResult<Tproducto>> PostTproducto(Tproducto tproducto)
        {
            return await _lproducto.PostProducto(tproducto);
        }

        // DELETE: api/Tproducto/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Tproducto>> DeleteTproducto(int id)
        {
            return await _lproducto.DeleteProducto(id);
        }
    }
}
