using Food_shop_backend.Models;
using Microsoft.EntityFrameworkCore;

namespace Food_shop_backend.Context
{
    public class Contexto: DbContext
    {
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        public Contexto(DbContextOptions<Contexto> options) : base(options)
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }
        public DbSet<Clientes> Clientes { get; set; }
        //hola
    }
}
