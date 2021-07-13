using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using Tienda.Models;
using c = Tienda.Logic.LCliente;

namespace Tienda.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TclienteController
    {
        private readonly TiendaContext _context;
        private c _lcliente;
        public TclienteController(TiendaContext context)
        {
            _context = context;
            _lcliente = new c(context);
        }

        // GET: api/Tcliente
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Tcliente>>> GetTcliente()
        {
            return await _lcliente.GetCliente();
        }

        // GET: api/Tcliente/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Tcliente>> GetTcliente(int id)
        {
            return await _lcliente.GetClienteById(id);
        }

        // PUT: api/Tcliente/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTcliente(int id, Tcliente tcliente)
        {
            return await _lcliente.PutCliente(id, tcliente);
        }

        // POST: api/Tcliente
        [HttpPost]
        public async Task<ActionResult<Tcliente>> PostTcliente(Tcliente tcliente)
        {
            return await _lcliente.PostCliente(tcliente);
        }

        // DELETE: api/Tcliente/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Tcliente>> DeleteTcliente(int id)
        {
            return await _lcliente.DeleteCliente(id);
        }


    }
}
