using ProyectoLP4.web;
using ProyectoLP4.web.Models;
using Microsoft.EntityFrameworkCore;
using ProyectoLP4.web.Data;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Identity.Client;

public class ListService : IListService
{
    //**SEGUNDA PRUEBA**

    private readonly List<UserList> _userLists = new();

    public Task<List<UserList>> GetListsAsync()
    {
        return Task.FromResult(_userLists);
    }

    public Task CrearListaAsync(string nombre)
    {
        _userLists.Add(new UserList { Nombre = nombre });
        return Task.CompletedTask;
    }

    public Task AgregarTituloAListaAsync(int listaId, Movie movie)
    {
        var lista = _userLists.Find(l => l.Id == listaId);
        if (lista != null)
        {
            lista.Movies.Add(movie);
        }
        return Task.CompletedTask;
    }

    //**PRIMERA PRUEBA**

    //private readonly ApplicationDbContext _context;

    //public ListService(ApplicationDbContext context)
    //{
    //_context = context;
    //}

    //Para obtener las listas
    //public async Task<List<UserList>> GetAllListsAsync()
    //{
    //return await _context.UserLists.Include(ul => ul.Movies).ToListAsync();
    //}

    //Para crear listas
    //public async Task CrearListaAsync (string listName)
    //{
    //if(string.IsNullOrEmpty(listName))
    //{
    //var newList = new UserList { Nombre = listName };
    //_context.UserLists.Add(newList);
    //await _context.SaveChangesAsync();
    //}
    //}

    //Función para agregar un título a una lista
    //public async Task AgregarTituloALista(int listID, Movie movie)
    //{
    //var lista = await _context.UserLists.FindAsync(listID);
    //if (lista != null)
    //{
    //lista.Movies.Add(movie);
    //await _context.SaveChangesAsync();
    //}
    //}
}
