using ProyectoLP4.web.Models;

public interface ITMDbservice
{
    Task<List<Movie>> SearchTitlesAsync(string query);
}