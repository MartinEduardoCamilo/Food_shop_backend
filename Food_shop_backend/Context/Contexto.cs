using Microsoft.EntityFrameworkCore;

namespace Food_shop_backend.Context
{
    public class Contexto: DbContext
    {
        public Contexto(DbContextOptions<Contexto> options) : base(options)
        {

        }
    }
}
