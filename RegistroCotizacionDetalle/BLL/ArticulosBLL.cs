﻿using RegistroCotizacionDetalle.DAL;
using RegistroCotizacionDetalle.Entidades;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace RegistroCotizacionDetalle.BLL
{
    public class ArticulosBLL
    {
        public static bool Guardar(Articulos Articulo)
        {
            bool paso = false;
            Contexto contexto = new Contexto();
            try
            {
                if (contexto.Articulo.Add(Articulo) != null)
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
      
        public static bool Modificar(Articulos Articulo)
        {

            bool paso = false;

            Contexto contexto = new Contexto();

            try
            {
                contexto.Entry(Articulo).State = EntityState.Modified;
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

                Articulos Articulo = contexto.Articulo.Find(id);
                contexto.Articulo.Remove(Articulo);
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
       

        public static Articulos Buscar(int id)
        {

            Articulos Articulo = new Articulos();
            Contexto contexto = new Contexto();

            try
            {
                Articulo = contexto.Articulo.Find(id);
                contexto.Dispose();

            }

            catch (Exception)
            {

                throw;

            }

            return Articulo;

        }
       
        public static List<Articulos> GetList(Expression<Func<Articulos, bool>> expression)
        {

            List<Articulos> Articulo = new List<Articulos>();
            Contexto contexto = new Contexto();

            try
            {

                Articulo = contexto.Articulo.Where(expression).ToList();
                contexto.Dispose();
            }
            catch (Exception)
            {

                throw;
            }

            return Articulo;
        }
    }
}

