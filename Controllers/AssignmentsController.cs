﻿using System;
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
    public class AssignmentsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AssignmentsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Assignments
        public async Task<IActionResult> Index()
        {
            return View(await _context.Assignments.ToListAsync());
        }

        // GET: Assignments/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var assignments = await _context.Assignments
                .FirstOrDefaultAsync(m => m.AssignmentID == id);
            if (assignments == null)
            {
                return NotFound();
            }

            return View(assignments);
        }

        // GET: Assignments/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Assignments/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AssignmentID,Task,Assigner,Assignee,AssignmentDate,ExpectedCompletionDate,Status,Deleted")] Assignments assignments)
        {
            if (ModelState.IsValid)
            {
                _context.Add(assignments);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(assignments);
        }

        // GET: Assignments/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var assignments = await _context.Assignments.FindAsync(id);
            if (assignments == null)
            {
                return NotFound();
            }
            return View(assignments);
        }

        // POST: Assignments/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("AssignmentID,Task,Assigner,Assignee,AssignmentDate,ExpectedCompletionDate,Status,Deleted")] Assignments assignments)
        {
            if (id != assignments.AssignmentID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(assignments);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AssignmentsExists(assignments.AssignmentID))
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
            return View(assignments);
        }

        // GET: Assignments/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var assignments = await _context.Assignments
                .FirstOrDefaultAsync(m => m.AssignmentID == id);
            if (assignments == null)
            {
                return NotFound();
            }

            return View(assignments);
        }

        // POST: Assignments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var assignments = await _context.Assignments.FindAsync(id);
            _context.Assignments.Remove(assignments);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AssignmentsExists(int id)
        {
            return _context.Assignments.Any(e => e.AssignmentID == id);
        }
    }
}
