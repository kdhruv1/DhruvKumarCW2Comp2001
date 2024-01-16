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
    public class UserTables1Controller2 : ControllerBase
    {
        private readonly Comp2001DkumarContext _context;

        public UserTables1Controller2(Comp2001DkumarContext context)
        {
            _context = context;
        }

        // GET: api/UserTables1Controller2
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserTable>>> GetUserTables()
        {
                 var userTables = await _context.UserTables
      .Select(userTable => new UserTable
      {
          UserId = userTable.UserId,
          UserName = userTable.UserName,
          AboutMe = userTable.AboutMe,
          Location = userTable.Location,
          Units = userTable.Units,
          ActivtiyPreference = userTable.ActivtiyPreference,
          Height = userTable.Height,
          Weight = userTable.Weight,
          Birthday = userTable.Birthday,
          MarketingLanguage = userTable.MarketingLanguage,

      })
      .ToListAsync();

            return userTables;



        }

        // PUT: 
        
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUserTable(int id, string email, UserTable userTable)
        {
            if (id != userTable.UserId)
            {
                return BadRequest();
            }

            if (email != userTable.Email)
            {
                return BadRequest();
            }
            _context.Entry(userTable).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserTableExists(id))
                {
                    return NotFound();
                }


                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/UserTables1Controller2
        [HttpPost]
        public async Task<ActionResult<UserTable>> PostUserTable(UserTable userTable)
        {
            _context.UserTables.Add(userTable);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUserTable", new { id = userTable.UserId }, userTable);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUserTable(int id, [FromBody] string email)
        {
            var userTable = await _context.UserTables.FindAsync(id);
            if (userTable == null)
            {
                return NotFound();
            }

            var userByEmail = await _context.UserTables.FirstOrDefaultAsync(u => u.Email == email);


            if (userByEmail == null || !userByEmail.Admin)
            {
                return Forbid("Invalid email for deletion or insufficient permissions.");
            }

            var archive = new Archive
            {
                UserId = userTable.UserId,
                UserName = userTable.UserName,
                Email = userTable.Email,
                AboutMe = userTable.AboutMe,
                Location = userTable.Location,
                Units = userTable.Units,
                ActivtiyPreference = userTable.ActivtiyPreference,
                Height = userTable.Height,
                Weight = userTable.Weight,
                Birthday = userTable.Birthday,
                MarketingLanguage = userTable.MarketingLanguage,
                Admin = userTable.Admin,
                Archive1 = true
            };

            archive.UserId = null;
            _context.UserTables.Remove(userTable);
            _context.Archives.Add(archive);

            await _context.SaveChangesAsync();

            return NoContent();
        }
        private bool UserTableExists(int id)
        {
            return _context.UserTables.Any(e => e.UserId == id);
        }
    }
}
