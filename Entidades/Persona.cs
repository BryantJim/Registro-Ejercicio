using System;
using System.Collections.Generic;
using System.Text;

namespace EjercicioRegistro.Entidades
{
    class Persona
    {
        public int ID { get; set; }
        public String Nombre { get; set; }
        public String Apellido { get; set; }
        public String Cedula { get; set; }
        public String Telefono { get; set; }
        public String Direccion { get; set; }
        //public DateTime FechaNaci { get; set; }

        public Persona()
        {
            ID = 0;
            Nombre = string.Empty;
            Apellido = string.Empty;
            Cedula = string.Empty;
            Telefono = string.Empty;
            Direccion = string.Empty;
            //FechaNaci = DateTime.Now;
        }
    }
}
