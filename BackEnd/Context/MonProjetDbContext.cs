using Microsoft.EntityFrameworkCore; 
using BackEnd.Class;

namespace BackEnd.Context
{
    public class MonProjetDbContext : DbContext
    {
        public MonProjetDbContext(DbContextOptions<MonProjetDbContext> options) : base(options)
        {
        }

        public DbSet<Personne> Personne { get; set; }
        // public DbSet<Produit> Produits { get; set; }
        // public DbSet<Commande> Commandes { get; set; }
    }
}
