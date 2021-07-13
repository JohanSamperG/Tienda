using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Tienda.Models
{
    public partial class Tcliente
    {
        public Tcliente()
        {
            Tcompra = new HashSet<Tcompra>();
            Tusuario = new HashSet<Tusuario>();
        }

        [Key]
        public int IdCliente { get; set; }
        [Required]
        public string Nombre { get; set; }
        [Required]
        public string Sexo { get; set; }
        [Required]
        public string Celular { get; set; }

        public virtual ICollection<Tcompra> Tcompra { get; set; }
        public virtual ICollection<Tusuario> Tusuario { get; set; }
    }
}
