using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

// Code scaffolded

namespace Tienda.Models
{
    public partial class Tproducto
    {
        public Tproducto()
        {
            Tcompra = new HashSet<Tcompra>();
        }
        [Key]
        public int IdProdcuto { get; set; }
        [Required]
        public string Nombre { get; set; }
        [Required]
        public decimal Precio { get; set; }
        [Required]
        public double CantidadRestante { get; set; }
        [Required]
        public string Marca { get; set; }

        public virtual ICollection<Tcompra> Tcompra { get; set; }
    }
}
