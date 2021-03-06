﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace RegistroCotizacionDetalle.Entidades
{
   public class Cotizaciones
    {

        [Key]
        public int CotizacionId { get; set; }
        public DateTime Fecha { get; set; }
        [StringLength(100)]
        public string Comentario { get; set; }
        public int Monto { get; set; }

        public virtual ICollection<CotizacionesDetalle> Detalle { get; set; }

        public Cotizaciones()
        {
            this.Detalle = new List<CotizacionesDetalle>();
        }

        public void AgregarDetalle(int id, int CotizacionId, int PersonaId, int ArticuloId, int Cantidad, int Precio, int Importe)
        {
            this.Detalle.Add(new CotizacionesDetalle(id, CotizacionId, PersonaId, ArticuloId, Cantidad, Precio, Importe));
        }
    }
}

