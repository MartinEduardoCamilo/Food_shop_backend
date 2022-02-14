using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Food_shop_backend.Models
{
    public class Producto
    {
        [Key]
        public int productoId { get; set; }
        [StringLength(15)]
        public string? nombre { get; set; }
        public decimal precio { get; set; }
        [StringLength(45)]
        public string? descripcion { get; set; }
        [ForeignKey("categoriaId")]
        public int categoriaId { get; set; }
        public virtual Categoria? categoria { get; set; }

        public Producto(int productoId, string? nombre, decimal precio, string? descripcion, int categoriaId)
        {
            this.productoId = productoId;
            this.nombre = nombre;
            this.precio = precio;
            this.descripcion = descripcion;
            this.categoriaId = categoriaId;
        }
    }
}
