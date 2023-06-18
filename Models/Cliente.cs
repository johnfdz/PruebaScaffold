using System;
using System.Collections.Generic;

namespace PruebaScaffold.Models
{
    public partial class Cliente
    {
        public Cliente()
        {
            Facturas = new HashSet<Factura>();
        }

        public int ClienteId { get; set; }
        public string? Nombre { get; set; }
        public string? Direccion { get; set; }
        public string? Ciudad { get; set; }
        public string? Estado { get; set; }
        public string? CodigoPostal { get; set; }

        public virtual ICollection<Factura> Facturas { get; set; }
    }
}
