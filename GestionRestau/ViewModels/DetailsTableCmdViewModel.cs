using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace GestionRestau.ViewModels
{
    public class DetailsTableCmdViewModel
    {

        public int Id { get; set; }
        public int Numero { get; set; }
        [DisplayName("Nombre de places")]
        public int NbPlace { get; set; }
        public bool Occupation { get; set; }
        public string Emplacement { get; set; }
        public int ServeurId { get; set; }
        public string Name { get; set; }
        public int Telephone { get; set; }

    }
}
