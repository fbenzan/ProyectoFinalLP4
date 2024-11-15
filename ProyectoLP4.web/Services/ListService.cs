using ProyectoLP4.web;
using ProyectoLP4.web.Models;
using Microsoft.EntityFrameworkCore;
using ProyectoLP4.web.Data;
using System.Collections.Generic;
using System.Threading.Tasks;

public class ListService
{
    private readonly ApplicationDbContext _context;
    
    public ListService(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<List<UserList>> GetAllListsAsync()
    {
        return await _context.UserLists.Include(ul => ul.Movies).ToListAsync();
    }
}
