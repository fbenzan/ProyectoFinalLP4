using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ProyectoLP4.web.Models
{
    [Table("Titulos")]
    public class Movie
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Titulo { get; set; }
        public string Overview { get; set; }
        public int TMDbId { get; set; } //Id de la pelicula en la API.
    }
}
