using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AuthApp.Data;
using AuthApp.Models;

namespace AuthApp.Controllers
{
    public class PrioritiesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PrioritiesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Priorities
        public async Task<IActionResult> Index()
        {
            return View(await _context.Priorities.ToListAsync());
        }

        // GET: Priorities/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var priorities = await _context.Priorities
                .FirstOrDefaultAsync(m => m.PriorityId == id);
            if (priorities == null)
            {
                return NotFound();
            }

            return View(priorities);
        }

        // GET: Priorities/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Priorities/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PriorityId,PriorityName,PriorityDescription,CreatedBy,CreatedDate,Deleted")] Priorities priorities)
        {
            if (ModelState.IsValid)
            {
                _context.Add(priorities);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(priorities);
        }

        // GET: Priorities/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var priorities = await _context.Priorities.FindAsync(id);
            if (priorities == null)
            {
                return NotFound();
            }
            return View(priorities);
        }

        // POST: Priorities/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int? id, [Bind("PriorityId,PriorityName,PriorityDescription,CreatedBy,CreatedDate,Deleted")] Priorities priorities)
        {
            if (id != priorities.PriorityId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(priorities);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PrioritiesExists(priorities.PriorityId))
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
            return View(priorities);
        }

        // GET: Priorities/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var priorities = await _context.Priorities
                .FirstOrDefaultAsync(m => m.PriorityId == id);
            if (priorities == null)
            {
                return NotFound();
            }

            return View(priorities);
        }

        // POST: Priorities/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int? id)
        {
            var priorities = await _context.Priorities.FindAsync(id);
            _context.Priorities.Remove(priorities);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PrioritiesExists(int? id)
        {
            return _context.Priorities.Any(e => e.PriorityId == id);
        }
    }
}
