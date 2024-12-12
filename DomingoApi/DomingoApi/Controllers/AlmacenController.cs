using DomingoApi.Context;
using Microsoft.AspNetCore.Mvc;

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




    }
}
