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
    public class BodegatripasController : Controller
    {
        private readonly ApplicationDbContext _context;
        private ClasificacionTripaModel listatipotripas;

        public BodegatripasController(ApplicationDbContext context)
        {
            _context = context;
            listatipotripas = new ClasificacionTripaModel(context);
        }
            public  List<ClasificacionTripa> Controladorlistatipotripa()
        {
            return listatipotripas.ClaseModeloListaClasificacionTripa();
        }
        // GET: Bodegatripas
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Bodegatripa.Include(b => b.ClasificacionTripa).Include(b => b.Descarnes);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Bodegatripas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bodegatripa = await _context.Bodegatripa
                .Include(b => b.ClasificacionTripa)
                .Include(b => b.Descarnes)
                .SingleOrDefaultAsync(m => m.BodegaTripaId == id);
            if (bodegatripa == null)
            {
                return NotFound();
            }

            return View(bodegatripa);
        }

        // GET: Bodegatripas/Create
        public IActionResult Create()
        {
            ViewData["ClasificacionTripaId"] = new SelectList(_context.ClasificacionTripa, "ClasificacionTripaId", "Detalle");
            ViewData["DescarneId"] = new SelectList(_context.Descarne, "DescarneId", "DescarneId");
            return View();
        }

        // POST: Bodegatripas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("BodegaTripaId,activo,NumeroPieles,peso,DescarneId,ClasificacionTripaId,Personal")] Bodegatripa bodegatripa)
        {
            if (ModelState.IsValid)
            {
                _context.Add(bodegatripa);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ClasificacionTripaId"] = new SelectList(_context.ClasificacionTripa, "ClasificacionTripaId", "Detalle", bodegatripa.ClasificacionTripaId);
            ViewData["DescarneId"] = new SelectList(_context.Descarne, "DescarneId", "DescarneId", bodegatripa.DescarneId);
            return View(bodegatripa);
        }

        // GET: Bodegatripas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bodegatripa = await _context.Bodegatripa.SingleOrDefaultAsync(m => m.BodegaTripaId == id);
            if (bodegatripa == null)
            {
                return NotFound();
            }
            ViewData["ClasificacionTripaId"] = new SelectList(_context.ClasificacionTripa, "ClasificacionTripaId", "Detalle", bodegatripa.ClasificacionTripaId);
            ViewData["DescarneId"] = new SelectList(_context.Descarne, "DescarneId", "DescarneId", bodegatripa.DescarneId);
            return View(bodegatripa);
        }

        // POST: Bodegatripas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("BodegaTripaId,activo,NumeroPieles,peso,DescarneId,ClasificacionTripaId,Personal")] Bodegatripa bodegatripa)
        {
            if (id != bodegatripa.BodegaTripaId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(bodegatripa);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BodegatripaExists(bodegatripa.BodegaTripaId))
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
            ViewData["ClasificacionTripaId"] = new SelectList(_context.ClasificacionTripa, "ClasificacionTripaId", "Detalle", bodegatripa.ClasificacionTripaId);
            ViewData["DescarneId"] = new SelectList(_context.Descarne, "DescarneId", "DescarneId", bodegatripa.DescarneId);
            return View(bodegatripa);
        }

        // GET: Bodegatripas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bodegatripa = await _context.Bodegatripa
                .Include(b => b.ClasificacionTripa)
                .Include(b => b.Descarnes)
                .SingleOrDefaultAsync(m => m.BodegaTripaId == id);
            if (bodegatripa == null)
            {
                return NotFound();
            }

            return View(bodegatripa);
        }

        // POST: Bodegatripas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var bodegatripa = await _context.Bodegatripa.SingleOrDefaultAsync(m => m.BodegaTripaId == id);
            _context.Bodegatripa.Remove(bodegatripa);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BodegatripaExists(int id)
        {
            return _context.Bodegatripa.Any(e => e.BodegaTripaId == id);
        }
    }
}
