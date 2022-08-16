using eTickets.Data;
using eTickets.Models;
using eTickets.Servcices;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace eTickets.Controllers
{
    public class ActorsController : Controller
    {
        private readonly IActorService _Service;

        public ActorsController(IActorService actorService)
        {
            _Service = actorService;
        }
        public async Task<IActionResult> Index()
        {
            var data = await _Service.GetAllAsync();
            return View(data);
        }
        public IActionResult Create()
        {
            
            return View();
        }
         
        [HttpPost]
        public async Task<IActionResult> Create ([Bind("FullName,ProfilePictureURL,Bio")]Actor actor)
        {
            if (!ModelState.IsValid)
            {
                return View(actor); 
            }
            await _Service.AddAsync(actor);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Details(int id)
        {
            var actorDetails = await _Service.GetByIdAsync(id);
            if (actorDetails == null) return View("Empty");
            return View(actorDetails);
        }
        // Get: Actors/Edit/1
        public async Task<IActionResult> Edit( int id)
        {
            var actorDetails = await _Service.GetByIdAsync(id);
            if (actorDetails == null) return View("Not Found");
            return View(actorDetails);
        }

        [HttpPost]
        public async Task<IActionResult> Edit( int id , Actor actor)
        {
            if (!ModelState.IsValid)
            {
                return View(actor);
            }
            await _Service.UpdateAsync(id, actor);
            return RedirectToAction(nameof(Index));
        }

        // Get: Actors/Delete/1
        public async Task<IActionResult> Delete(int id)
        {
            var actorDetails = await _Service.GetByIdAsync(id);
            if (actorDetails == null) return View("Not Found");
            return View(actorDetails);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var actorDetails = await _Service.GetByIdAsync(id);
            if (actorDetails == null) return View("Not Found");
            await _Service.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
