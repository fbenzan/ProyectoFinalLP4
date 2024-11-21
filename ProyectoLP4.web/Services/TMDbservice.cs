using System.Net.Http;
using System.Threading.Tasks;
using System.Text.Json;
using System.Collections.Generic;
using Microsoft.Extensions.Configuration;
using ProyectoLP4.web.Models;

public class TMDbService : ITMDbservice
{
    private readonly HttpClient _httpClient;
    private const string ApiKey = "f080810985003cec1aeef1e10d5ce41b";
    private const string BaseUrl = "https://api.themoviedb.org/3/";

    public TMDbService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<List<Movie>> SearchTitlesAsync(string query)
    {
        try
        {
            Console.WriteLine("Entrando a SearchTitlesAsync");
            if (string.IsNullOrWhiteSpace(query))
            {
                Console.WriteLine("El query está vacío o nulo.");
                return new List<Movie>();
            }

            var movieTask = _httpClient.GetAsync($"{BaseUrl}search/movie?api_key={ApiKey}&query={Uri.EscapeDataString(query)}");
            var tvTask = _httpClient.GetAsync($"{BaseUrl}search/tv?api_key={ApiKey}&query={Uri.EscapeDataString(query)}");

            await Task.WhenAll(movieTask, tvTask);

            Console.WriteLine("Llamadas a la API completadas.");

            var movieResults = await ParseResponseAsync(movieTask.Result);
            var tvResults = await ParseResponseAsync(tvTask.Result);

            Console.WriteLine($"Películas encontradas: {movieResults.Count}");
            Console.WriteLine($"Series encontradas: {tvResults.Count}");

            return movieResults.Concat(tvResults).ToList();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Ocurrió un error: {ex.Message}");
            return new List<Movie>();
        }


        #region Old and new code (Not using)
        //var movieResults = movieTask.IsSuccessStatusCode
        //? JsonSerializer.Deserialize<TMDbSearchResult>(await movieTask.Content.ReadAsStringAsync(), new JsonSerializerOptions { PropertyNameCaseInsensitive = true })?.Results
        //: new List<Movie>();

        //var tvResults = tvTask.IsSuccessStatusCode
        //? JsonSerializer.Deserialize<TMDbSearchResult>(await tvTask.Content.ReadAsStringAsync(), new JsonSerializerOptions { PropertyNameCaseInsensitive = true })?.Results
        //: new List<Movie>();

        //return movieResults.Concat(tvResults).ToList();

        //OLD CODE

        //var response = await _httpClient.GetAsync($"{BaseUrl}search/movie?api_key={ApiKey}&query={Uri.EscapeDataString(query)}");
        //response.EnsureSuccessStatusCode();

        //var json = await response.Content.ReadAsStringAsync();
        //var result = JsonSerializer.Deserialize<TMDbSearchResult>(json, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
        //return result?.Results ?? new List<Movie>();
        #endregion
    }

    private async Task<List<Movie>> ParseResponseAsync(HttpResponseMessage response)
    {
        if (!response.IsSuccessStatusCode)
        {
            Console.WriteLine($"Error en la respuesta: {response.StatusCode}");
            return new List<Movie>();
        }

        var json = await response.Content.ReadAsStringAsync();
        Console.WriteLine($"Respuesta JSON: {json}");

        var result = JsonSerializer.Deserialize<TMDbSearchResult>(json, new JsonSerializerOptions { PropertyNameCaseInsensitive = true});
        return result?.Results ?? new List<Movie>();
    }
}

public class TMDbSearchResult
{
    public List<Movie> Results { get; set; }
}
