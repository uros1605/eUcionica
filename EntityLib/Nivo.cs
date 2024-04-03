using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLib
{
    public class Nivo
    {
        [Key]
        public int NivoID { get; set; }
        public string Naziv { get; set; }

        public ICollection<Pitanje> NivozaPitanje { get; set; } = new List<Pitanje>();
    }
}
