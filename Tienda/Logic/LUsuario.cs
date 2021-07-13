using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tienda.Models;

namespace Tienda.Logic
{
    public class LUsuario : ControllerBase
    {
        private readonly TiendaContext _context;
        public LUsuario(TiendaContext context)
        {
            _context = context;
        }
    }
}
