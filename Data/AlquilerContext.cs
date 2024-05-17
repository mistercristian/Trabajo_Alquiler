using Microsoft.AspNetCore.Razor.TagHelpers;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using Trabajo_Alquiler.Models;

namespace Trabajo_Alquiler.Data
{
    public class AlquilerContext: DbContext
    {

        public AlquilerContext(DbContextOptions<AlquilerContext> options) : base(options)
        {
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Propiedad> Propiedades { get; set; }
        public DbSet<Inquilino> Inquilinos { get; set; }
        public DbSet<Contrato> Contratos { get; set; }
        public DbSet<Pago> Pagos { get; set; }
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                "Server=(localdb)\\MSSQLLocalDB;Database=Trabajo_Alquiler;Trusted_Connection=True;");
        }
    }
}

