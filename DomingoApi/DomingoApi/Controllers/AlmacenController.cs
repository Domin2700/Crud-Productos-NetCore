using DomingoApi.Context;
using DomingoApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DomingoApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class AlmacenController : Controller
    {
        public readonly ApplicationDbContext _context;

        public AlmacenController(ApplicationDbContext context)
        {
            _context = context;
        }



        [HttpGet("getProductos")]
        public async Task<ActionResult<Producto>> GetProductos()
        {
            var productos = await _context.Producto.ToListAsync();
            return Ok(productos);
        }

        [HttpGet("getProducto/{productoid:int}")]
        public async Task<ActionResult<Producto>> GetProducto(int productoid)
        {
            var producto = await _context.Producto.Where(w => w.ProductoID == productoid).ToListAsync();
            return Ok(producto);
        }



        [HttpPost("insertProducto")]
        public async Task<ActionResult> InsertProducto([FromBody] Producto producto)
        {

            if (ModelState.IsValid)
            {
                var productoExiste = await _context.Producto.AnyAsync(a => a.ProductoID == producto.ProductoID);
                if (productoExiste)
                {
                    ModelState.AddModelError("Mensaje", "El producto ya existe");
                    return BadRequest(ModelState);
                }
                await _context.Producto.AddAsync(producto);
                int x = await _context.SaveChangesAsync();

                if (x > 0)
                {
                    return Ok();
                }
                else
                {
                    ModelState.AddModelError("Mensaje", "Error al guardar los datos");
                    return BadRequest(ModelState);
                }
            }
            else
            {
                ModelState.AddModelError("Mensaje", ModelState.ToString());
                return BadRequest(ModelState);
            }


        }

        [HttpPut("updateProducto/{productoid:int}")]
        public async Task<ActionResult> UpdateProducto( int productoid, [FromBody] Producto producto)
        {
            if (ModelState.IsValid)
            {
                if (productoid != producto.ProductoID)
                {
                    ModelState.AddModelError("Mensaje", "El id no coincide");
                    return BadRequest(ModelState);
                }

                _context.Producto.Update(producto);
                int x = await _context.SaveChangesAsync();

                if (x > 0)
                {
                    return Ok();
                }
                else
                {
                    ModelState.AddModelError("Mensaje", "Error al actualizar los datos");
                    return BadRequest(ModelState);
                }
            }
            else
            {
                ModelState.AddModelError("Mensaje", ModelState.ToString());
                return BadRequest(ModelState);
            }

        }


        [HttpDelete("deleteProduct/{productoid}")]
        public async Task<ActionResult<Producto>> DeleteProducto([FromRoute] int productoid)
        {

            var producto = await _context.Producto.FirstOrDefaultAsync(f => f.ProductoID == productoid);

            if (producto == null)
            {
                ModelState.AddModelError("Mensaje", "Producto no existe");
                return BadRequest(ModelState);
            }


            _context.Entry(producto).State = EntityState.Deleted;
            _context.SaveChanges();
            return Ok();
        }

    }
}
