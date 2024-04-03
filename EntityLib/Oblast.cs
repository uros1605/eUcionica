using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLib
{
    public class Oblast
    {
        public Predmet Predmet { get; set; }
        public int PredmetID { get; set; }
        [ForeignKey("PredmetID")]

        [Key]
        public int OblastID { get; set; }
        public string Naziv { get; set; }

        public ICollection<Pitanje> OblastzaPitanje { get; set; } = new List<Pitanje>();
    }
}
