using eTickets.Data;
using eTickets.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eTickets.Servcices
{
    public class ActorService:IActorService
    {
        private readonly AppDbContext _context;

        public ActorService(AppDbContext appDbContext)
        {
            _context = appDbContext;
        }

        public async Task<IEnumerable<Actor>> GetAllAsync()
        {
            var data = await _context.Actors.ToListAsync();
            return data;
        }
        public async Task AddAsync(Actor actor)
        {
            await _context.Actors.AddAsync(actor);
            await _context.SaveChangesAsync();
        }

        public async Task<Actor> GetByIdAsync (int id)
        {
            var result = await _context.Actors.FirstOrDefaultAsync(n => n.Id == id);
            return result;
        }

        public async Task<Actor> UpdateAsync(int id, Actor actor)
        {
            _context.Update(actor);
            await _context.SaveChangesAsync();
            return actor;
            //var result = await _context.Actors.FirstOrDefaultAsync(n => n.Id == id);
            //return result;
        }

        public async Task DeleteAsync(int id)
        {

            var result = await _context.Actors.FirstOrDefaultAsync(n => n.Id == id);
            _context.Actors.Remove(result);
            await _context.SaveChangesAsync();
            

        }

        //public async Task<Actor> Delete(int id)
        //{
        //    await _context.Actors.Remove(id);
        //    await _context.SaveChangesAsync();

        //}

    }
}
