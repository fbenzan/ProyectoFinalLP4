using ProyectoLP4.web.Models;

public interface ITMDbservice
{
    Task<List<Movie>> BuscarPeliculasAsync(string query);
}