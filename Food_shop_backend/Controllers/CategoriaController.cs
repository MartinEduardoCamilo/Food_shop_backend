using Food_shop_backend.Context;
using Food_shop_backend.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Food_shop_backend.Controllers
{
    [Route("api/categoria")]
    [ApiController]
    public class CategoriaController : ControllerBase
    {

        private readonly Contexto _contexto;

        public CategoriaController(Contexto contexo)
        {
            _contexto = contexo;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Categoria>>> GetCategorias()
        {

            List<Categoria>? categorias;
            try
            {
               categorias = await _contexto.categorias.ToListAsync();
                if(categorias == null)
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
            return Ok(categorias);
        }

      
        [HttpGet("{id}")]
        public async Task<ActionResult> GetCategoria(int id)
        {
            Categoria? categoria;
            try
            {
                categoria = await _contexto.categorias.FindAsync(id);
                if(categoria == null)
                {
                    return BadRequest();
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
            return Ok(categoria);
        }

        
        [HttpPost]
        public async Task<ActionResult> PostCategoria([FromBody] Categoria categoria)
        {
            try
            {
                await _contexto.categorias.AddAsync(categoria);
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
        public async Task<ActionResult> PutCategoria(int id, [FromBody] Categoria categoria)
        {
            try
            {
                _contexto.categorias.Update(categoria);
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

      
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
               Categoria? categoria = await _contexto.categorias.FindAsync(id);
                if(categoria == null)
                {
                    return BadRequest();
                }
                else
                {
                    _contexto.categorias.Remove(categoria);
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
