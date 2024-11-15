using System.Net.Http;
using System.Threading.Tasks;
using System.Text.Json;
using Microsoft.Extensions.Configuration;

public class TMDbservice
{
    private readonly HttpClient _httpClient;
    private readonly string _apiKey;

    public TMDbservice(HttpClient httpClient, IConfiguration configuration)
    {
        _httpClient = httpClient;
        _apiKey = configuration["TMDbApiKey"];
    }

    public async Task<dynamic> BuscarPeliculasAsync(string query)
    {
        var respuesta = await _httpClient.GetStringAsync($"https://api.themoviedb.org/3/search/movie?api_key={_apiKey}&query={query}");
        return JsonSerializer.Deserialize<dynamic>(respuesta);
    }

    public async Task<dynamic> GetMovieDetailAsync(int movieId)
    {
        var respuesta = await _httpClient.GetStringAsync($"https://api.themoviedb.org/3/movie/{movieId}?api_key={_apiKey}");
        return JsonSerializer.Deserialize<dynamic>(respuesta);
    }
}
