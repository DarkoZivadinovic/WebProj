using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Models
{
    [Table("Film")]
    public class Film
    {
        [Key]
        public int ID { get; set; }


        [Required]
        public int Sifra { get; set; }


        [Required]
        [MaxLength(50)]
        public string Naziv { get; set; }

        public virtual Filmoteka Filmoteka{ get; set; }

        public virtual Zanr Zanr{ get; set; }
        
        [JsonIgnore]
        public virtual List<Iznajmljivanje> FilmKorisnik { get; set; }

    }


}