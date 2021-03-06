using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GestionRestau.ViewModels;

namespace GestionRestau.Models.Context
{
    public class ApplicationDbContext : DbContext
    {

        public ApplicationDbContext(DbContextOptions options) : base(options)
        {

        }

       



        public DbSet<Serveur> Serveurs { get; set; } //DBset represnts une table
        public DbSet<TableCmd> TableCmds { get; set; }
        public DbSet<Produit> Produits { get; set; }
        public DbSet<Consommation> Consommations { get; set; }
        
    }
}
