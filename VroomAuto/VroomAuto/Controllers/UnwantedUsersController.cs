using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using VroomAuto.AppLogic.Models;
using VroomAuto.DataAccess;

namespace VroomAuto.Controllers
{
    [Authorize(Roles = "Admin")]
    public class UnwantedUsersController : Controller
    {
        private readonly VroomAutoDbContext _context;

        public UnwantedUsersController(VroomAutoDbContext context)
        {
            _context = context;
        }

        // GET: UnwantedUsers
        public async Task<IActionResult> Index()
        {
            return View(await _context.UnwantedUsers.ToListAsync());
        }

        // GET: UnwantedUsers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var unwantedUser = await _context.UnwantedUsers
                .FirstOrDefaultAsync(m => m.ID == id);
            if (unwantedUser == null)
            {
                return NotFound();
            }

            return View(unwantedUser);
        }

        // GET: UnwantedUsers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: UnwantedUsers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,CNP")] UnwantedUser unwantedUser)
        {
            if (ModelState.IsValid)
            {
                _context.Add(unwantedUser);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(unwantedUser);
        }

        // GET: UnwantedUsers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var unwantedUser = await _context.UnwantedUsers.FindAsync(id);
            if (unwantedUser == null)
            {
                return NotFound();
            }
            return View(unwantedUser);
        }

        // POST: UnwantedUsers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,CNP")] UnwantedUser unwantedUser)
        {
            if (id != unwantedUser.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(unwantedUser);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UnwantedUserExists(unwantedUser.ID))
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
            return View(unwantedUser);
        }

        // GET: UnwantedUsers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var unwantedUser = await _context.UnwantedUsers
                .FirstOrDefaultAsync(m => m.ID == id);
            if (unwantedUser == null)
            {
                return NotFound();
            }

            return View(unwantedUser);
        }

        // POST: UnwantedUsers/Delete/5
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var unwantedUser = await _context.UnwantedUsers.FindAsync(id);
            _context.UnwantedUsers.Remove(unwantedUser);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UnwantedUserExists(int id)
        {
            return _context.UnwantedUsers.Any(e => e.ID == id);
        }
    }
}
