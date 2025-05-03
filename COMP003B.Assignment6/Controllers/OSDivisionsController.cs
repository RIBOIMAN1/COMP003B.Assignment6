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
	public class OSDivisionsController : Controller
	{
		private readonly WorkplaceContext _context;

		public OSDivisionsController(WorkplaceContext context)
		{
			_context = context;
		}

		// GET: OSDivisions
		public async Task<IActionResult> Index()
		{
			return View(await _context.OSDivisions.ToListAsync());
		}

		// GET: OSDivisions/Details/5
		public async Task<IActionResult> Details(int? id)
		{
			if (id == null)
			{
				return NotFound();
			}

			var oSDivision = await _context.OSDivisions
				.FirstOrDefaultAsync(m => m.DivisionId == id);
			if (oSDivision == null)
			{
				return NotFound();
			}

			ViewBag.OSExperiences = _context.OSExperiences
				.Where(e => e.OSDivisionId == id)
				.ToList();
			return View(oSDivision);
		}

		// GET: OSDivisions/Create
		public IActionResult Create()
		{
			return View();
		}

		// POST: OSDivisions/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Create([Bind("DivisionId,Title")] OSDivision oSDivision)
		{
			if (ModelState.IsValid)
			{
				_context.Add(oSDivision);
				await _context.SaveChangesAsync();
				return RedirectToAction(nameof(Index));
			}
			return View(oSDivision);
		}

		// GET: OSDivisions/Edit/5
		public async Task<IActionResult> Edit(int? id)
		{
			if (id == null)
			{
				return NotFound();
			}

			var oSDivision = await _context.OSDivisions.FindAsync(id);
			if (oSDivision == null)
			{
				return NotFound();
			}
			return View(oSDivision);
		}

		// POST: OSDivisions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Edit(int id, [Bind("DivisionId,Title")] OSDivision oSDivision)
		{
			if (id != oSDivision.DivisionId)
			{
				return NotFound();
			}

			if (ModelState.IsValid)
			{
				try
				{
					_context.Update(oSDivision);
					await _context.SaveChangesAsync();
				}
				catch (DbUpdateConcurrencyException)
				{
					if (!OSDivisionExists(oSDivision.DivisionId))
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
			return View(oSDivision);
		}

		// GET: OSDivisions/Delete/5
		public async Task<IActionResult> Delete(int? id)
		{
			if (id == null)
			{
				return NotFound();
			}

			var oSDivision = await _context.OSDivisions
				.FirstOrDefaultAsync(m => m.DivisionId == id);
			if (oSDivision == null)
			{
				return NotFound();
			}

			return View(oSDivision);
		}

		// POST: OSDivisions/Delete/5
		[HttpPost, ActionName("Delete")]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> DeleteConfirmed(int id)
		{
			var oSDivision = await _context.OSDivisions.FindAsync(id);
			if (oSDivision != null)
			{
				_context.OSDivisions.Remove(oSDivision);
			}

			await _context.SaveChangesAsync();
			return RedirectToAction(nameof(Index));
		}

		private bool OSDivisionExists(int id)
		{
			return _context.OSDivisions.Any(e => e.DivisionId == id);
		}
	}
}