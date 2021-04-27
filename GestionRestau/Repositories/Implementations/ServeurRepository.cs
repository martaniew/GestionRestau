using GestionRestau.Models;
using GestionRestau.Models.Context;
using GestionRestau.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GestionRestau.Repositories.Implementations
{
    public class ServeurRepository : IServeurRepository
    {
        private readonly ApplicationDbContext _dbContext; //creer noveau object de la class Dependency injection 
        public ServeurRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public ICollection <Serveur> GetAll ()
        {
           var serveurs = _dbContext.Serveurs.ToList();
            return serveurs; 
        }

        public void Insert(Serveur serveur)
        {
            _dbContext.Serveurs.Add(serveur); 
        }

        public Serveur GetById(int Id)
            {
           return  _dbContext.Serveurs.Find(Id);
        }

        public void Update (Serveur serveur)
        {
            _dbContext.Entry(serveur).State = Microsoft.EntityFrameworkCore.EntityState.Modified; 
        }

        public void DelateById(int Id)
        {
            var serveurToDelate = _dbContext.Serveurs.Find(Id);
            _dbContext.Serveurs.Remove(serveurToDelate);
        }

        public void Save() //enregistrement fait dans le DBContext 
        {
            _dbContext.SaveChanges();
        }
    }
}
