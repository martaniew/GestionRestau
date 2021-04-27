using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GestionRestau.Models
{
    public class Serveur
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Telephone { get; set; }

        public virtual ICollection<TableCmd> Tables { get; set; }

    }
}
