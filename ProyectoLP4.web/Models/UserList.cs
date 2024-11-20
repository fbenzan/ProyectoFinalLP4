using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace ProyectoLP4.web.Models
{
    [Table("ListaDeUsuario")]
    public class UserList
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Nombre { get; set; }
        public List<Movie> Movies { get; set; } = new();
    }
}
