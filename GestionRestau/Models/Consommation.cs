using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GestionRestau.Models
{
    //Test commit
    //Test commit 2
    public class Consommation
    {
        public int Id { get; set; }
       
        public DateTime Data { get; set; }
        public int Quantite { get; set; }
        public bool Paye { get; set; }
        public virtual TableCmd TableCons { get; set; }
        public int TableId { get; set; }
        public virtual Produit Produit { get; set; }
        public int ProduitId { get; set; }
    }
}
