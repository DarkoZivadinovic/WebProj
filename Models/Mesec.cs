using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Models
{
    [Table("Mesec")]
    public class Mesec
    {
        [Key]
        public int ID { get; set; }


        [Required]
        [MaxLength(10)]
        public string Naziv { get; set; }

        [JsonIgnore]
        public virtual List<Iznajmljivanje> MesecIznajmljivanje { get; set; }
    }


}