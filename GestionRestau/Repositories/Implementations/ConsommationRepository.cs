using GestionRestau.Models;
using GestionRestau.Models.Context;
using GestionRestau.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GestionRestau.Repositories.Implementations
{
    public class ConsommationRepository : IConsommationRepository
    {
        private readonly ApplicationDbContext _dbContext; //creer noveau object de la class Dependency injection 
        public ConsommationRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public ICollection<Consommation> GetAll()
        {
            var consommations = _dbContext.Consommations.ToList();
            return consommations;
        }

        public void Insert(Consommation consommation)
        {
            _dbContext.Consommations.Add(consommation);
        }

        public Consommation GetById(int Id)
        {
            return _dbContext.Consommations.Find(Id);
        }

        public void Update(Consommation consommation)
        {
            _dbContext.Entry(consommation).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
        }

        public void DelateById(int Id)
        {
            var consommationToDelate = _dbContext.Consommations.Find(Id);
            _dbContext.Consommations.Remove(consommationToDelate);
        }

        public void Save() //enregistrement fait dans le DBContext 
        {
            _dbContext.SaveChanges();
        }
    }
}

