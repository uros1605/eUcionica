using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLib
{
    public class Predmet
    {
        [Key]
        public int PredmetID { get; set; }
        public string Naziv { get; set; }

        public ICollection<Pitanje> PitanjazaPredmet { get; set; } = new List<Pitanje>();
        public ICollection<Oblast> OblastzaPredmet { get; set; } = new List<Oblast>();
    }
}