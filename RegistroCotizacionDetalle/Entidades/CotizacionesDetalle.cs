using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace RegistroCotizacionDetalle.Entidades
{
    public class CotizacionesDetalle
    {
        [Key]
        public int Id { get; set; }
        public int CotizacionId { get; set; }
        public int PersonaId { get; set; }
        public int ArticuloId { get; set; }
        public int Cantidad { get; set; }
        public int Precio { get; set; }
        public int Importe { get; set; }

        [ForeignKey("ArticuloId")]
        public virtual Articulos Articulos { get; set; }

        [ForeignKey("PersonaId")]
        public virtual Personas Persona { get; set; }

        public CotizacionesDetalle()
        {
            this.Id = 0;
            this.CotizacionId = 0;

        }

        public CotizacionesDetalle(int id, int cotizacionId, int personaId, int articuloId, int cantidad, int precio, int importe)
        {
            Id = id;
            CotizacionId = cotizacionId;
            PersonaId = personaId;
            ArticuloId = articuloId;
            Cantidad = cantidad;
            Precio = precio;
            Importe = importe;
        }
    }
}