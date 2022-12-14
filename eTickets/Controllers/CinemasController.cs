using eTickets.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace eTickets.Controllers
{
    public class CinemasController : Controller
    {
        private readonly AppDbContext _context;

        public CinemasController(AppDbContext appDbContext)
        {
            _context = appDbContext;
        }
        public async Task<IActionResult> Index()
        {
            var cinemas = await _context.cinemas.ToListAsync();
            return View(cinemas);
        }
    }
}
