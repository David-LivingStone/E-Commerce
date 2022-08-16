using eTickets.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace eTickets.Controllers
{
    public class ProducersController : Controller
    {
        private readonly AppDbContext _context;

        public ProducersController(AppDbContext appDbContext)
        {
            _context = appDbContext;
        }
        public async Task <IActionResult> Index()
        {
            var Producers = await _context.producers.ToListAsync();
            return View(Producers);
        }
    }
}
