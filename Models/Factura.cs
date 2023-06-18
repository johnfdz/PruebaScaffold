using System;
using System.Collections.Generic;

namespace PruebaScaffold.Models
{
    public partial class Factura
    {
        public Factura()
        {
            DetallesFacturas = new HashSet<DetallesFactura>();
        }

        public int FacturaId { get; set; }
        public int? ClienteId { get; set; }
        public DateTime? Fecha { get; set; }
        public decimal? Total { get; set; }

        public virtual Cliente? Cliente { get; set; }
        public virtual ICollection<DetallesFactura> DetallesFacturas { get; set; }
    }
}
