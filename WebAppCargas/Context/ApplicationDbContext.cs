
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAppCargas.Models;
using WebAppCargas.Context;
using WebAppCargas.Controllers;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore.Proxies;



namespace WebAppCargas.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
        //Acá van las tablas        
        public DbSet<Producto> Productos { get; set; }
        public DbSet<Categoria> Categorias { get; set; }



        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)

           => optionsBuilder
        .UseLazyLoadingProxies()
        .UseSqlServer("server=.;database=Loading;trusted_connection=true;");


    }
}
