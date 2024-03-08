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

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=localhost;Database=Caez;User=Jeffrey;Password=jeffrey20068f;Encrypt=true;TrustServerCertificate=true;");
        }

    }
}
