using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GestionRestau.Models
{
    public class Produit
    {
        public int Id { get; set; }
        public string Nom { get; set; }
        public string Description { get; set; }
        public float Prix { get; set; }
        public string Categorie { get; set; }
        public string Statut { get; set; }
        public string CentreDeRevenu { get; set; }
        public int Nbpersonne { get; set; }
        public virtual ICollection<Consommation>Consommations { get; set; }
    }
}
