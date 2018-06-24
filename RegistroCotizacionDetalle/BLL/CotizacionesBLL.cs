using RegistroCotizacionDetalle.DAL;
using RegistroCotizacionDetalle.Entidades;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace RegistroCotizacionDetalle.BLL
{
    public class CotizacionesBLL
    {
        public static bool Guardar(Cotizaciones Cotizacion)
        {
            bool paso = false;

            Contexto contexto = new Contexto();
            try
            {
                if (contexto.Cotizacion.Add(Cotizacion) != null)
                {
                    contexto.SaveChanges();
                    paso = true;
                }

                contexto.Dispose();
            }
            catch (Exception)
            {
                throw;
            }
            return paso;
        }

        public static bool Modificar(Cotizaciones Cotizacion)
        {

            bool paso = false;

            Contexto contexto = new Contexto();

            try
            {
                foreach (var item in Cotizacion.Detalle)
                {
                  
                    var estado = item.Id > 0 ? EntityState.Modified : EntityState.Added;
                    contexto.Entry(item).State = estado;
                }

                
                contexto.Entry(Cotizacion).State = EntityState.Modified;

                if (contexto.SaveChanges() > 0)
                {
                    paso = true;
                }
                contexto.Dispose();
            }
            catch (Exception)
            {
                throw;
            }
            return paso;

        }

        public static bool Eliminar(int id)
        {

            bool paso = false;

            Contexto contexto = new Contexto();

            try
            {

                Cotizaciones Cotizacion = contexto.Cotizacion.Find(id);
                contexto.Cotizacion.Remove(Cotizacion);
                if (contexto.SaveChanges() > 0)
                {

                    paso = true;

                }

                contexto.Dispose();

            }

            catch (Exception)
            {

                throw;

            }

            return paso;
        }

        public static Cotizaciones Buscar(int id)
        {

            Cotizaciones Cotizacion = new Cotizaciones();
            Contexto contexto = new Contexto();

            try
            {
                Cotizacion = contexto.Cotizacion.Find(id);
                Cotizacion.Detalle.Count();

                foreach (var item in Cotizacion.Detalle)
                {
                   
                    string s = item.Articulos.Descripcion;
                    string r = item.Persona.Nombres;
                }
                contexto.Dispose();
            }

            catch (Exception)
            {

                throw;

            }

            return Cotizacion;

        }

        public static List<Cotizaciones> GetList(Expression<Func<Cotizaciones, bool>> expression)
        {

            List<Cotizaciones> Cotizacion = new List<Cotizaciones>();
            Contexto contexto = new Contexto();

            try
            {

                Cotizacion = contexto.Cotizacion.Where(expression).ToList();
                contexto.Dispose();
            }
            catch (Exception)
            {

                throw;
            }

            return Cotizacion;
        }


    }
}

