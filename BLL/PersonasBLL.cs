using System;
using System.Collections.Generic;
using System.Text;
using EjercicioRegistro.Entidades;
using EjercicioRegistro.DAL;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using System.Linq;

namespace EjercicioRegistro.BLL
{
    class PersonasBLL
    {
        //Guarda una persona
        public static bool Guardar(Persona persona) 
        {
            bool paso = false;
            Contexto db = new Contexto();

            try
            {
                if (db.Personas.Add(persona) != null)
                    paso = (db.SaveChanges()>0);
            }
            catch (Exception) 
            {
                throw;
            }
            finally
            {
                db.Dispose();
            }
            return paso;
        }
        //Modifica una persona que estaba guardada
        public static bool Modificar(Persona persona) 
        {
            bool paso = false;
            Contexto db = new Contexto();

            try
            {
                db.Entry(persona).State = EntityState.Modified;
                paso = (db.SaveChanges() > 0);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                db.Dispose();
            }
            return paso;
        }
        //Elimina una persona guardada
        public static bool Eliminar(int Id) 
        {
            bool paso = false;
            Contexto db = new Contexto();

            try
            {
                var Eliminar = db.Personas.Find(Id);
                db.Entry(Eliminar).State = EntityState.Deleted;

                paso = (db.SaveChanges() > 0);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                db.Dispose();
            }
            return paso;
        }
        //Buscar una persona guardada
        public static Persona Buscar(int Id) 
        {
            Contexto db = new Contexto();
            Persona persona = new Persona();

            try
            {
                persona = db.Personas.Find(Id);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                db.Dispose();
            }
            return persona;
        }
        public static List<Persona> GetList(Expression<Func<Persona,bool>>persona)
        {
            List<Persona> Lista = new List<Persona>();
            Contexto db = new Contexto();

            try
            {
                Lista = db.Personas.Where(persona).ToList();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                db.Dispose();    
            }
            return Lista;
        }
    }
}
