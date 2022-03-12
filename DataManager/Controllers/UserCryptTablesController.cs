#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DataManager.Data;
using DataManager.Model;

namespace DataManager.Controllers
{
    public class UserCryptTablesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public UserCryptTablesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: UserCryptTables
        public async Task<IActionResult> Index()
        {
            return View(await _context.UserCryptTable.ToListAsync());
        }

        // GET: UserCryptTables/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userCryptTable = await _context.UserCryptTable
                .FirstOrDefaultAsync(m => m.Name == id);
            if (userCryptTable == null)
            {
                return NotFound();
            }

            return View(userCryptTable);
        }

        // GET: UserCryptTables/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: UserCryptTables/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name,EncryptedName")] UserCryptTable userCryptTable)
        {
            if (ModelState.IsValid)
            {
                _context.Add(userCryptTable);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(userCryptTable);
        }

        // GET: UserCryptTables/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userCryptTable = await _context.UserCryptTable.FindAsync(id);
            if (userCryptTable == null)
            {
                return NotFound();
            }
            return View(userCryptTable);
        }

        // POST: UserCryptTables/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Name,EncryptedName")] UserCryptTable userCryptTable)
        {
            if (id != userCryptTable.Name)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(userCryptTable);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UserCryptTableExists(userCryptTable.Name))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(userCryptTable);
        }

        // GET: UserCryptTables/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userCryptTable = await _context.UserCryptTable
                .FirstOrDefaultAsync(m => m.Name == id);
            if (userCryptTable == null)
            {
                return NotFound();
            }

            return View(userCryptTable);
        }

        // POST: UserCryptTables/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var userCryptTable = await _context.UserCryptTable.FindAsync(id);
            _context.UserCryptTable.Remove(userCryptTable);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UserCryptTableExists(string id)
        {
            return _context.UserCryptTable.Any(e => e.Name == id);
        }
    }
}
