using GestionRestau.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GestionRestau.Repositories.Interfaces
{
    public interface IConsommationRepository
    {
        public ICollection<Consommation> GetAll();
        public void Insert(Consommation consommation);
        public Consommation GetById(int Id);
        public void Update(Consommation consommation);
        public void DelateById(int Id);
        public void Save();
    }
}
