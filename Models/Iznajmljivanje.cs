using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Models
{
    [Table("Iznajmljivanje")]
    public class Iznajmljivanje
    {
        public int ID { get; set; }
        public virtual Korisnik Korisnik { get; set; }
        public virtual Film Film { get; set; }
        public virtual Mesec Mesec { get; set; }
        public virtual Filmoteka Filmoteka { get; set; }
    }


}