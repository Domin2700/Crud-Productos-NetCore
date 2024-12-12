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

        public AlmacenController(ApplicationDbContext context) {
            _context = context;
        }



        [HttpGet("getProductos")]
        public async Task<ActionResult<Producto>> getProductos()
        {
            var productos = await _context.Producto.ToListAsync();
            return Ok(productos);
        }

        [HttpGet("getProducto/{productoid:int}")]
        public async Task<ActionResult<Producto>> getProducto(int productoid)
        {
            var producto = await _context.Producto.Where(w => w.ProductID == productoid).ToListAsync();
            return Ok(producto);
        }

    }
}
