using Food_shop_backend.Models;
using Microsoft.EntityFrameworkCore;

namespace Food_shop_backend.Context
{
    public class Contexto: DbContext
    {
        public Contexto(DbContextOptions<Contexto> options) : base(options) { }
        public DbSet<Clientes> Clientes { get; set; }
        public DbSet<Categoria> categorias { get; set; }
        public DbSet<Producto> productos { get; set; }
    }
}
