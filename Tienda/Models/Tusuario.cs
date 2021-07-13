using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Tienda.Models
{
    public partial class Tusuario
    {
        [Key]
        public int IdUsuario { get; set; }
        [Required]
        public int IdCliente { get; set; }
        [Required]
        public string Usuario { get; set; }
        [Required]
        public string Contraseña { get; set; }

        public virtual Tcliente IdClienteNavigation { get; set; }
    }
}
