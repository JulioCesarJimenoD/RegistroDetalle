using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RegistroDetalles.Entidades;

namespace RegistroDetalles.DAL
{
    public class Contexto : DbContext
    {
        public DbSet <Roles> Roles { get; set; }
        public DbSet <Usuarios> Usuarios { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(@"Data source = DATA\RegistroDetalle.db");
        }
    }
}
