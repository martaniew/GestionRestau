using GestionRestau.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GestionRestau.Repositories.Interfaces
{
    interface IProduitRepository
    {
        public ICollection<Produit> GetAll();
        public void Insert(Produit produit);
        public Produit GetById(int Id);
        public void Update(Produit produit);
        public void DelateById(int Id);
        public void Save();
    }
}
