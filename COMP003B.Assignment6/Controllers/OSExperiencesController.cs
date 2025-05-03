using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using COMP003B.Assignment6.Data;
using COMP003B.Assignment6.Models;

namespace COMP003B.Assignment6.Controllers
{
    public class OSExperiencesController : Controller
    {
        private readonly WorkplaceContext _context;

        public OSExperiencesController(WorkplaceContext context)
        {
            _context = context;
        }

        // GET: OSExperiences
        public async Task<IActionResult> Index()
        {
            return View(await _context.OSExperiences.ToListAsync());
        }

        // GET: OSExperiences/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var oSExperience = await _context.OSExperiences
                .FirstOrDefaultAsync(m => m.Id == id);
            if (oSExperience == null)
            {
                return NotFound();
            }

            return View(oSExperience);
        }

        // GET: OSExperiences/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: OSExperiences/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Email,OSType")] OSExperience oSExperience)
        {
            if (ModelState.IsValid)
            {
                _context.Add(oSExperience);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(oSExperience);
        }

        // GET: OSExperiences/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var oSExperience = await _context.OSExperiences.FindAsync(id);
            if (oSExperience == null)
            {
                return NotFound();
            }
            return View(oSExperience);
        }

        // POST: OSExperiences/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Email,OSType")] OSExperience oSExperience)
        {
            if (id != oSExperience.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(oSExperience);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OSExperienceExists(oSExperience.Id))
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
            return View(oSExperience);
        }

        // GET: OSExperiences/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var oSExperience = await _context.OSExperiences
                .FirstOrDefaultAsync(m => m.Id == id);
            if (oSExperience == null)
            {
                return NotFound();
            }

            return View(oSExperience);
        }

        // POST: OSExperiences/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var oSExperience = await _context.OSExperiences.FindAsync(id);
            if (oSExperience != null)
            {
                _context.OSExperiences.Remove(oSExperience);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OSExperienceExists(int id)
        {
            return _context.OSExperiences.Any(e => e.Id == id);
        }
    }
}
