using GestionRestau.Models;
using GestionRestau.Models.Context;
using GestionRestau.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GestionRestau.Repositories.Implementations
{
    public class ProduitRepository : IProduitRepository
    {
        private readonly ApplicationDbContext _dbContext; //creer noveau object de la class Dependency injection 
        public ProduitRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public ICollection<Produit> GetAll()
        {
            var produits = _dbContext.Produits.ToList();
            return produits;
        }

        public void Insert(Produit produit)
        {
            _dbContext.Produits.Add(produit);
        }

        public Produit GetById(int Id)
        {
            return _dbContext.Produits.Find(Id);
        }

        public void Update(Produit produit)
        {
            _dbContext.Entry(produit).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
        }

        public void DelateById(int Id)
        {
            var produitToDelate = _dbContext.Produits.Find(Id);
            _dbContext.Produits.Remove(produitToDelate);
        }

        public void Save() //enregistrement fait dans le DBContext 
        {
            _dbContext.SaveChanges();
        }
    }
}
