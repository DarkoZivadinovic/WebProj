using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Models
{
    [Table("Korisnik")]
    public class Korisnik
    {
        [Key]
        public int ID { get; set; }


        [Required]
        public int RegistarskiBroj { get; set; }


        [Required]
        [MaxLength(30)]
        public string Ime { get; set; }


        [Required]
        [MaxLength(30)]
        public string Prezime { get; set; }

        public virtual Filmoteka Filmoteka{ get; set; }


        [JsonIgnore]
        public virtual List<Iznajmljivanje> KorisnikFilm { get; set; }

    }



}