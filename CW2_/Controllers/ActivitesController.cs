using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CW2_.Models;

namespace CW2_.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ActivitesController : ControllerBase
    {
        private readonly Comp2001DkumarContext _context;

        public ActivitesController(Comp2001DkumarContext context)
        {
            _context = context;
        }

        // GET: api/Activites
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Activite>>> GetActivites()
        {
            return await _context.Activites.ToListAsync();
        }

      

        // POST: api/Activites
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Activite>> PostActivite(Activite activite)
        {
            _context.Activites.Add(activite);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetActivite", new { id = activite.FavouriteActivitiesId }, activite);
        }

        // DELETE: api/Activites/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteActivite(int id)
        {
            var activite = await _context.Activites.FindAsync(id);
            if (activite == null)
            {
                return NotFound();
            }

            _context.Activites.Remove(activite);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ActiviteExists(int id)
        {
            return _context.Activites.Any(e => e.FavouriteActivitiesId == id);
        }
    }
}
