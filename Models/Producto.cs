using System;
using System.Collections.Generic;

namespace PruebaScaffold.Models
{
    public partial class Producto
    {
        public Producto()
        {
            DetallesFacturas = new HashSet<DetallesFactura>();
        }

        public int ProductoId { get; set; }
        public string? Nombre { get; set; }
        public decimal? Precio { get; set; }
        public string? Descripcion { get; set; }

        public virtual ICollection<DetallesFactura> DetallesFacturas { get; set; }
    }
}
