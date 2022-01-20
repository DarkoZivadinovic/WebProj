using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Models
{
    [Table("Filmoteka")]
    public class Filmoteka
    {
        [Key]
        public int ID { get; set; }

        [Required]
        [MaxLength(50)]
        public string Naziv { get; set; }
        
        [JsonIgnore]
        public virtual List<Film> FilmotekaFilm { get; set; }

        [JsonIgnore]
        public virtual List<Korisnik> FilmotekaKorisnik { get; set; }

        [JsonIgnore]
        public virtual List<Iznajmljivanje> FilmFilmoteka { get; set; }

    }


}