using Food_shop_backend.Context;
using Food_shop_backend.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Food_shop_backend.Controllers
{
    [Route("api/productos")]
    [ApiController]
    public class ProductosController : ControllerBase
    {
        private readonly Contexto _contexto;
        public ProductosController(Contexto contexto)
        {
            _contexto = contexto;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Producto>>> GetProductos()
        {
            List<Producto>? productos;
            try
            {
                productos = await _contexto.productos.ToListAsync();
                if(productos is null)
                {
                    return NotFound();
                }
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                await _contexto.DisposeAsync();
            }
            return Ok(productos);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetProduto(int id)
        {
            Producto? produto;
            try
            {
                produto = await _contexto.productos.Where(x => x.productoId == id).Include(c=> c.categoria).FirstOrDefaultAsync();
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                await _contexto.DisposeAsync();
            }
            return Ok(produto);
        }

        [HttpPost]
        public async Task<ActionResult> PostProducto([FromBody] Producto producto)
        {
            try
            {
                await _contexto.productos.AddAsync(producto);
                await _contexto.SaveChangesAsync();

            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                await _contexto.DisposeAsync();
            }

            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> PutProducto(int id, [FromBody] Producto producto)
        {
            try
            {
                 _contexto.Update(producto);
                await _contexto.SaveChangesAsync();

            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                _contexto?.DisposeAsync();
            }
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteProducto(int id)
        {
            try
            {
                Producto? Producto = await _contexto.productos.FindAsync(id);
                if(Producto == null)
                {
                    return BadRequest();
                }
                else
                {
                    _contexto.productos.Remove(Producto);
                    await _contexto.SaveChangesAsync();
                }
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                await _contexto.DisposeAsync();
            }
            return Ok();
        }
    }
}
