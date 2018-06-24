using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace RegistroCotizacionDetalle.Entidades
{
    public class Articulos
    {
        [Key]
        public int ArticuloID { get; set; }
        public DateTime FechaVencimiento { get; set; }
        public string Descripcion { get; set; }
        public int Precio { get; set; }
        public int CantidadCotizado { get; set; }

        public Articulos()
        {
            ArticuloID = 0;
            FechaVencimiento = DateTime.Now;
            Descripcion = string.Empty;
            Precio = 0;
            CantidadCotizado = 0;
        }

        public override string ToString()
        {
            return this.Descripcion;
        }
    }
}
