using System.ComponentModel.DataAnnotations;

namespace FilmesApi.Models
{
    public class Endereco
    {
        [Key]
        [Required]
        public int id { get; set; }
        [Required]
        public string Logradouro { get; set; }
        [Required]
        public string Numero { get; set; }

        public virtual Cinema Cinema { get; set; }
    }
}
