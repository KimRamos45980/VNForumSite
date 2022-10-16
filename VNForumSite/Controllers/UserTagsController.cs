using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using VNForumSite.Data;
using VNForumSite.Models;

namespace VNForumSite.Controllers
{
    public class UserTagsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public UserTagsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: UserTags
        public async Task<IActionResult> Index()
        {
              return View(await _context.UserTags.ToListAsync());
        }

        // GET: UserTags/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.UserTags == null)
            {
                return NotFound();
            }

            var userTags = await _context.UserTags
                .FirstOrDefaultAsync(m => m.Id == id);
            if (userTags == null)
            {
                return NotFound();
            }

            return View(userTags);
        }

        // GET: UserTags/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: UserTags/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Tag")] UserTags userTags)
        {
            if (ModelState.IsValid)
            {
                _context.Add(userTags);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(userTags);
        }

        // GET: UserTags/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.UserTags == null)
            {
                return NotFound();
            }

            var userTags = await _context.UserTags.FindAsync(id);
            if (userTags == null)
            {
                return NotFound();
            }
            return View(userTags);
        }

        // POST: UserTags/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Tag")] UserTags userTags)
        {
            if (id != userTags.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(userTags);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UserTagsExists(userTags.Id))
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
            return View(userTags);
        }

        // GET: UserTags/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.UserTags == null)
            {
                return NotFound();
            }

            var userTags = await _context.UserTags
                .FirstOrDefaultAsync(m => m.Id == id);
            if (userTags == null)
            {
                return NotFound();
            }

            return View(userTags);
        }

        // POST: UserTags/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.UserTags == null)
            {
                return Problem("Entity set 'ApplicationDbContext.UserTags'  is null.");
            }
            var userTags = await _context.UserTags.FindAsync(id);
            if (userTags != null)
            {
                _context.UserTags.Remove(userTags);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UserTagsExists(int id)
        {
          return _context.UserTags.Any(e => e.Id == id);
        }
    }
}
