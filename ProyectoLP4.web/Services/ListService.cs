using ProyectoLP4.web;
using ProyectoLP4.web.Models;
using Microsoft.EntityFrameworkCore;
using ProyectoLP4.web.Data;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Identity.Client;

public class ListService
{
    private readonly ApplicationDbContext _context;
    
    public ListService(ApplicationDbContext context)
    {
        _context = context;
    }

    //Para obtener las listas
    public async Task<List<UserList>> GetAllListsAsync()
    {
        return await _context.UserLists.Include(ul => ul.Movies).ToListAsync();
    }

    //Para crear listas
    public async Task CrearListaAsync (string listName)
    {
        if(string.IsNullOrEmpty(listName))
        {
            var newList = new UserList { Nombre = listName };
            _context.UserLists.Add(newList);
            await _context.SaveChangesAsync();
        }
    }

    //Función para agregar un título a una lista
    public async Task AgregarTituloALista(int listID, Movie movie)
    {
        var lista = await _context.UserLists.FindAsync(listID);
        if (lista != null)
        {
            lista.Movies.Add(movie);
            await _context.SaveChangesAsync();
        }
    }
}
