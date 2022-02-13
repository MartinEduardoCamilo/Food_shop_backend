using System.ComponentModel.DataAnnotations;

namespace Food_shop_backend.Models
{
    public class Categoria
    {
        [Key]
        public int categoriaId { get; set; }
        [StringLength(15)]
        public string? nombre { get; set; }

        public Categoria(int categoriaId, string? nombre)
        {
            this.categoriaId = categoriaId;
            this.nombre = nombre;
        }

        public Categoria()
        {
            this.categoriaId = 0;
            this.nombre = string.Empty;
        }
    }
}
