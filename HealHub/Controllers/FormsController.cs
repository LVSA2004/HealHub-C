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
    public class FormsController : Controller
    {
        private readonly OracleDBContext _context;

        public FormsController(OracleDBContext context)
        {
            _context = context;
        }

        // GET: Forms
        public async Task<IActionResult> Index()
        {
              return _context.FormList != null ? 
                          View(await _context.FormList.ToListAsync()) :
                          Problem("Entity set 'OracleDBContext.FormList'  is null.");
        }

        // GET: Forms/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.FormList == null)
            {
                return NotFound();
            }

            var form = await _context.FormList
                .FirstOrDefaultAsync(m => m.id == id);
            if (form == null)
            {
                return NotFound();
            }

            return View(form);
        }

        // GET: Forms/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Forms/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,userId,age,weight,height,symptoms,duration,diseaseHistory")] Form form)
        {
            if (ModelState.IsValid)
            {
                _context.Add(form);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(form);
        }

        // GET: Forms/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.FormList == null)
            {
                return NotFound();
            }

            var form = await _context.FormList.FindAsync(id);
            if (form == null)
            {
                return NotFound();
            }
            return View(form);
        }

        // POST: Forms/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,userId,age,weight,height,symptoms,duration,diseaseHistory")] Form form)
        {
            if (id != form.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(form);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FormExists(form.id))
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
            return View(form);
        }

        // GET: Forms/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.FormList == null)
            {
                return NotFound();
            }

            var form = await _context.FormList
                .FirstOrDefaultAsync(m => m.id == id);
            if (form == null)
            {
                return NotFound();
            }

            return View(form);
        }

        // POST: Forms/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.FormList == null)
            {
                return Problem("Entity set 'OracleDBContext.FormList'  is null.");
            }
            var form = await _context.FormList.FindAsync(id);
            if (form != null)
            {
                _context.FormList.Remove(form);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FormExists(int id)
        {
          return (_context.FormList?.Any(e => e.id == id)).GetValueOrDefault();
        }
    }
}
