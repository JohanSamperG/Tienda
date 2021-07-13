using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using Tienda.Models;
using lc = Tienda.Logic.LCompra;

namespace Tienda.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TcompraController : ControllerBase
    {
        private readonly TiendaContext _context;
        private lc _lcompra;
        public TcompraController(TiendaContext context)
        {
            _context = context;
            _lcompra = new lc(context);
        }

        // GET: api/Tcompra
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Tcompra>>> GetTcompra()
        {
            return await _lcompra.GetCompra();
        }

        // GET: api/Tcompra/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Tcompra>> GetTcompra(int id)
        {
            return await _lcompra.GetCompraById(id);
        }

        // PUT: api/Tcompra/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTcompra(int id, Tcompra tcompra)
        {
            return await _lcompra.PutCompra(id, tcompra);
        }

        // POST: api/Tcompra
        [HttpPost]
        public async Task<ActionResult<Tcompra>> PostTcompra(Tcompra tcompra)
        {
            return await _lcompra.PostCompra(tcompra);
        }

        // DELETE: api/Tcompra/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Tcompra>> DeleteTcompra(int id)
        {
            return await _lcompra.DeleteCompra(id);
        }

    }
}
