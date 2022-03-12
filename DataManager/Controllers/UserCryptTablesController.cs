#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DataManager.Data;
using DataManager.Model;

namespace DataManager.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserCryptTablesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public UserCryptTablesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/UserCryptTables
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserCryptTable>>> GetUserCryptTable()
        {
            return await _context.UserCryptTable.ToListAsync();
        }

        // GET: api/UserCryptTables/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UserCryptTable>> GetUserCryptTable(string id)
        {
            var userCryptTable = await _context.UserCryptTable.FindAsync(id);

            if (userCryptTable == null)
            {
                return NotFound();
            }

            return userCryptTable;
        }

        // PUT: api/UserCryptTables/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUserCryptTable(string id, UserCryptTable userCryptTable)
        {
            if (id != userCryptTable.Name)
            {
                return BadRequest();
            }

            _context.Entry(userCryptTable).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserCryptTableExists(id))
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

        // POST: api/UserCryptTables
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<UserCryptTable>> PostUserCryptTable(UserCryptTable userCryptTable)
        {
            _context.UserCryptTable.Add(userCryptTable);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (UserCryptTableExists(userCryptTable.Name))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetUserCryptTable", new { id = userCryptTable.Name }, userCryptTable);
        }

        // DELETE: api/UserCryptTables/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUserCryptTable(string id)
        {
            var userCryptTable = await _context.UserCryptTable.FindAsync(id);
            if (userCryptTable == null)
            {
                return NotFound();
            }

            _context.UserCryptTable.Remove(userCryptTable);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool UserCryptTableExists(string id)
        {
            return _context.UserCryptTable.Any(e => e.Name == id);
        }
    }
}
