using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using HealHub.Models;
using HealHub.Persistence;

namespace HealHub.Controllers
{
    public class PrognosisController : Controller
    {
        private readonly OracleDBContext _context;

        public PrognosisController(OracleDBContext context)
        {
            _context = context;
        }

        // GET: Prognosis
        public async Task<IActionResult> Index()
        {
              return _context.PrognosisList != null ? 
                          View(await _context.PrognosisList.ToListAsync()) :
                          Problem("Entity set 'OracleDBContext.PrognosisList'  is null.");
        }

        // GET: Prognosis/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.PrognosisList == null)
            {
                return NotFound();
            }

            var prognosis = await _context.PrognosisList
                .FirstOrDefaultAsync(m => m.Id == id);
            if (prognosis == null)
            {
                return NotFound();
            }

            return View(prognosis);
        }

        // GET: Prognosis/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Prognosis/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,formId,description")] Prognosis prognosis)
        {
            if (ModelState.IsValid)
            {
                _context.Add(prognosis);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(prognosis);
        }

        // GET: Prognosis/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.PrognosisList == null)
            {
                return NotFound();
            }

            var prognosis = await _context.PrognosisList.FindAsync(id);
            if (prognosis == null)
            {
                return NotFound();
            }
            return View(prognosis);
        }

        // POST: Prognosis/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,formId,description")] Prognosis prognosis)
        {
            if (id != prognosis.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(prognosis);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PrognosisExists(prognosis.Id))
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
            return View(prognosis);
        }

        // GET: Prognosis/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.PrognosisList == null)
            {
                return NotFound();
            }

            var prognosis = await _context.PrognosisList
                .FirstOrDefaultAsync(m => m.Id == id);
            if (prognosis == null)
            {
                return NotFound();
            }

            return View(prognosis);
        }

        // POST: Prognosis/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.PrognosisList == null)
            {
                return Problem("Entity set 'OracleDBContext.PrognosisList'  is null.");
            }
            var prognosis = await _context.PrognosisList.FindAsync(id);
            if (prognosis != null)
            {
                _context.PrognosisList.Remove(prognosis);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PrognosisExists(int id)
        {
          return (_context.PrognosisList?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
