using APP2024P4.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace APP2024P4.Data.Context
{
    public interface IAppDbContext
    {
        DbSet<Categoria> categorias { get; set; }
        DbSet<Marca> marcas { get; set; }
        DbSet<Modelo> modelos { get; set; }
        DbSet<Producto> productos { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}