using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GestionRestau.Models
{

    [Index(nameof(Name), IsUnique = true)]

    public class Serveur
    {
        public int Id { get; set; }
        [Required (ErrorMessage ="name is required")]
        public string Name { get; set; }
        public int Telephone { get; set; }
        [StringLength(50, MinimumLength = 10,
        ErrorMessage = "L'adresse doit impérativement avoir plus de 10 char")]
        public string Adress { get; set; }

        public string Email { get; set; }
        public virtual ICollection<TableCmd> Tables { get; set; }

    }
}
