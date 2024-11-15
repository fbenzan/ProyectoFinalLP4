namespace ProyectoLP4.web.Models
{
    public class Movie
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Descripcion { get; set; }
        public int TMBdId { get; set; } //Id de la pelicula en la API.
    }
}
