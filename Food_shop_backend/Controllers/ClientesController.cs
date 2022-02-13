using Food_shop_backend.Context;
using Food_shop_backend.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Food_shop_backend.Controllers
{
    [Route("api/clientes")]
    [ApiController]
    public class ClientesController : ControllerBase
    {
        private readonly Contexto _contexto;

        public ClientesController(Contexto contexto)
        {
            _contexto = contexto;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Clientes>>> GetCliente()
        {
            List<Clientes>? clientes;
            try
            {
                clientes = _contexto.Clientes.ToList();

                if (clientes is null)
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
            return Ok(clientes);
        }


        [HttpGet("{id}")]
        public async Task<ActionResult> GetCliente(int id)
        {
            Clientes? clientes;
            try
            {
                clientes = await _contexto.Clientes.FindAsync(id);
                if(clientes is null)
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
            return Ok(clientes);
        }

        [HttpPost]
        public async Task<ActionResult> PostCliente([FromBody] Clientes clientes)
        {     
            try
            {
                await _contexto.Clientes.AddAsync(clientes);
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
        public async Task<ActionResult> PutCliente(int id, [FromBody] Clientes clientes)
        {
            try
            {
                _contexto.Clientes.Update(clientes);
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
        public async Task<ActionResult> DeleteCliente(int id)
        {
            try
            {
                Clientes? clientes = await _contexto.Clientes.FindAsync(id);
                if (clientes == null)
                {
                    return BadRequest();
                }
                else
                {
                    _contexto.Clientes.Remove(clientes);
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
