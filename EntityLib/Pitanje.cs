using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLib
{
    public class Pitanje
    {
       
        public Predmet Predmet { get; set; }
        public int PredmetID { get; set; }
        [ForeignKey("PredmetID")]

        public Oblast Oblast { get; set; }
        public int OblastID { get; set; }
        [ForeignKey("OblastID")]

        public Nivo Nivo { get; set; }
        public int NivoID { get; set; }
        [ForeignKey("NivoID")]

        [Key]
        public int PitanjeID { get; set; }
        
        [Required]
        public string Tekst { get; set; }

        public string Odgovor { get; set; }

        public string? Slika { get; set; }


    }
}
