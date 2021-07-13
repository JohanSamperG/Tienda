using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Tienda.Models
{
    public partial class Tcompra
    {
        [Key]
        public int IdCompra { get; set; }
        [Required]
        public int IdCliente { get; set; }
        [Required]
        public int IdProducto { get; set; }
        [Required]
        public double CantidadTotal { get; set; }
        [Required]
        public decimal ValorTotal { get; set; }

        public virtual Tcliente IdClienteNavigation { get; set; }
        public virtual Tproducto IdProductoNavigation { get; set; }
    }
}
