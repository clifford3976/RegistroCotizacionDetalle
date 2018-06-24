﻿using RegistroCotizacionDetalle.Entidades;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;

namespace RegistroCotizacionDetalle.DAL
{
    public class Contexto : DbContext
    {
        public DbSet<Articulos> Articulo { get; set; }
        public DbSet<Personas> Persona { get; set; }
        public DbSet<Cotizaciones> Cotizacion { get; set; }

       
        public Contexto() : base("ConStr") { }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
