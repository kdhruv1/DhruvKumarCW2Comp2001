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
    public class ArchivesController : ControllerBase
    {
        private readonly Comp2001DkumarContext _context;

        public ArchivesController(Comp2001DkumarContext context)
        {
            _context = context;
        }

        // GET: api/Archives
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Archive>>> GetArchives()
        {
            return await _context.Archives.ToListAsync();
        }

       
       

        // DELETE: api/Archives/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteArchive(int id)
        {
            var archive = await _context.Archives.FindAsync(id);
            if (archive == null)
            {
                return NotFound();
            }

            _context.Archives.Remove(archive);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ArchiveExists(int id)
        {
            return _context.Archives.Any(e => e.ArchiveId == id);
        }
    }
}
