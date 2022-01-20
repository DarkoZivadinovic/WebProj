using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Models
{
    [Table("Zanr")]
    public class Zanr
    {
        [Key]
        public int ID { get; set; }


        [Required]
        [MaxLength(30)]
        public string Naziv { get; set; }

        [JsonIgnore]
        public virtual List<Film> FilmZanr { get; set; }

    }


}