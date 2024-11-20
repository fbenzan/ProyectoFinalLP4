using ProyectoLP4.web.Models;

public interface IListService
{
    Task AgregarTituloAListaAsync(int listaId, Movie movie);
    Task CrearListaAsync(string nombre);
    Task<List<UserList>> GetListsAsync();
}