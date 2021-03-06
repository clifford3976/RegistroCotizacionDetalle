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
    public class PersonasBLL
    {
        public static bool Guardar(Personas Persona)
        {
            bool paso = false;
            Contexto contexto = new Contexto();
            try
            {
                if (contexto.Persona.Add(Persona) != null)
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

        
        public static bool Modificar(Personas Persona)
        {
            bool paso = false;
            Contexto contexto = new Contexto();
            try
            {
                contexto.Entry(Persona).State = EntityState.Modified;
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
                Personas Persona = contexto.Persona.Find(id);

                contexto.Persona.Remove(Persona);

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

        public static Personas Buscar(int id)
        {
            Contexto contexto = new Contexto();
            Personas Persona = new Personas();
            try
            {
                Persona = contexto.Persona.Find(id);
                contexto.Dispose();
            }
            catch (Exception)
            {

                throw;
            }
            return Persona;
        }
    
       
        public static List<Personas> GetList(Expression<Func<Personas, bool>> expression)
        {
            List<Personas> Persona = new List<Personas>();
            Contexto contexto = new Contexto();
            try
            {
                Persona = contexto.Persona.Where(expression).ToList();
                contexto.Dispose();
            }
            catch (Exception)
            {

                throw;
            }

            return Persona;
        }
    }
}
