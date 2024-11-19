using APP2024P4.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace APP2024P4.Data.Context
{
    //agregar la interface
    public class AppDbContext : DbContext, IAppDbContext
    {
        private readonly IConfiguration confi;

        public AppDbContext(IConfiguration confi)
        {
            this.confi = confi;
        }

        public DbSet<Producto> productos { get; set; }
        public DbSet<Categoria> categorias { get; set; }
        public DbSet<Modelo> modelos { get; set; }
        public DbSet<Marca> marcas { get; set; }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            return base.SaveChangesAsync(cancellationToken);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(confi.GetConnectionString("MSSQL"));
        }
    }
}
