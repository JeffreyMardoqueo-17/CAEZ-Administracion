using CAEZ.Administracion.EN;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace GestordeTareas.DAL
{
    public class ContextoBD : DbContext
    {
        public DbSet<Cargo> Cargo { get; set; }
        public DbSet<Direccion> Direccion { get; set; }
        public DbSet<Grado> Grado { get; set; }
        public DbSet<Mes> Mes { get; set; }
        public DbSet<Parentezco> Parentezco { get; set; }
        public DbSet<TipoDocumento> TipoDocumento { get; set; }
        public DbSet<TipoPago> TipoPago { get; set; }
        public DbSet<Administrador> Administrador { get; set; }
        //public DbSet<Alumno> Alumno { get; set; }
        //public DbSet<Encargado> Encargado { get; set; }
        //public DbSet<Factura> Factura { get; set; }
        //public DbSet<Pago> Pago { get; set; }
        public DbSet<Turno> Turno { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=localhost;Database=Caez;User=Jeffrey;Password=jeffrey20068f;Encrypt=true;TrustServerCertificate=true;");
        }

    }
}