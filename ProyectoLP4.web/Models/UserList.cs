namespace ProyectoLP4.web.Models
{
    public class UserList
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public List<Movie> Movies { get; set; } = new();
    }
}
