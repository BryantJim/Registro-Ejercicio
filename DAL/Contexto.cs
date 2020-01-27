using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using EjercicioRegistro.Entidades;


namespace EjercicioRegistro.DAL
{
    class Contexto : DbContext
    {
        public DbSet<Persona> Persona { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server= BRYANTPC\SQLEXPRESS;Database =PersonasDb;Trusted_Connection=True;");
        }
    }
}
