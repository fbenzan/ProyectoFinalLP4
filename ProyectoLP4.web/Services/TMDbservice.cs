using System.Net.Http;
using System.Threading.Tasks;
using System.Text.Json;
using System.Collections.Generic;
using Microsoft.Extensions.Configuration;
using ProyectoLP4.web.Models;

public class TMDbservice : ITMDbservice
{
    private readonly HttpClient _httpClient;
    private const string ApiKey = "f080810985003cec1aeef1e10d5ce41b";
    private const string BaseUrl = "https://api.themoviedb.org/3/";

    public TMDbservice(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<List<Movie>> BuscarPeliculasAsync(string query)
    {
        var respuesta = await _httpClient.GetAsync($"{BaseUrl}search/movie?api_key={ApiKey}&query={Uri.EscapeDataString(query)}");
        respuesta.EnsureSuccessStatusCode();

        var json = await respuesta.Content.ReadAsStringAsync();
        var result = JsonSerializer.Deserialize<TMDbSearchResult>(json, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
        return result?.Results ?? new List<Movie>();
    }
}

public class TMDbSearchResult
{
    public List<Movie> Results { get; set; }
}
