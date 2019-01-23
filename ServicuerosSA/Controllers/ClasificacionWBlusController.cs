using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ServicuerosSA.Data;
using ServicuerosSA.Models;

namespace ServicuerosSA.Controllers
{
    public class ClasificacionWBlusController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ClasificacionWBlusController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: ClasificacionWBlus
        public async Task<IActionResult> Index()
        {
            return View(await _context.ClasificacionWB.ToListAsync());
        }

        // GET: ClasificacionWBlus/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var clasificacionWB = await _context.ClasificacionWB
                .SingleOrDefaultAsync(m => m.ClasificacionwbId == id);
            if (clasificacionWB == null)
            {
                return NotFound();
            }

            return View(clasificacionWB);
        }

        // GET: ClasificacionWBlus/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ClasificacionWBlus/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ClasificacionwbId,Fecha,NumeroPieles,Observaciones")] ClasificacionWB clasificacionWB)
        {
            if (ModelState.IsValid)
            {
                _context.Add(clasificacionWB);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(clasificacionWB);
        }

        // GET: ClasificacionWBlus/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var clasificacionWB = await _context.ClasificacionWB.SingleOrDefaultAsync(m => m.ClasificacionwbId == id);
            if (clasificacionWB == null)
            {
                return NotFound();
            }
            return View(clasificacionWB);
        }

        // POST: ClasificacionWBlus/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ClasificacionwbId,Fecha,NumeroPieles,Observaciones")] ClasificacionWB clasificacionWB)
        {
            if (id != clasificacionWB.ClasificacionwbId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(clasificacionWB);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ClasificacionWBExists(clasificacionWB.ClasificacionwbId))
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
            return View(clasificacionWB);
        }

        // GET: ClasificacionWBlus/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var clasificacionWB = await _context.ClasificacionWB
                .SingleOrDefaultAsync(m => m.ClasificacionwbId == id);
            if (clasificacionWB == null)
            {
                return NotFound();
            }

            return View(clasificacionWB);
        }

        // POST: ClasificacionWBlus/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var clasificacionWB = await _context.ClasificacionWB.SingleOrDefaultAsync(m => m.ClasificacionwbId == id);
            _context.ClasificacionWB.Remove(clasificacionWB);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ClasificacionWBExists(int id)
        {
            return _context.ClasificacionWB.Any(e => e.ClasificacionwbId == id);
        }
    }
}
