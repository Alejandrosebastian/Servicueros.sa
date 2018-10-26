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
    public class ClasificacionTripasController : Controller
    {
        private readonly ApplicationDbContext _context;
        private ClasificacionTripaModel clasetripa;
        private ClasificacionTripaModel listabode;
       
        public ClasificacionTripasController(ApplicationDbContext context)
        {
            _context = context;
            clasetripa = new ClasificacionTripaModel(_context);
            listabode = new ClasificacionTripaModel(_context);
        }

        // GET: ClasificacionTripas
        public async Task<IActionResult> Index()
        {
            return View(await _context.ClasificacionTripa.ToListAsync());
        }
       public List<Bodega> controladorlistabode()
        {
            return listabode.Claselistabode();
        }
      

        public List<object[]> Controladorlistadescarne()
        {
            return clasetripa.ModeloFiltrarClasificacionTripa();
        }
        public List<object[]>ControladorImprimirDescarne(string id)
        {
            return clasetripa.ModeloImprimirClasiTripa(id);
        }
        public List<object[]> ControladorImprimirCarnaza()
        {
            return clasetripa.ModeloImprimirCarnaza();
        }
     
        // GET: ClasificacionTripas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var clasificacionTripa = await _context.ClasificacionTripa
                .SingleOrDefaultAsync(m => m.ClasificacionTripaId == id);
            if (clasificacionTripa == null)
            {
                return NotFound();
            }

            return View(clasificacionTripa);
        }

        // GET: ClasificacionTripas/Create
        public IActionResult Create()
        {
            return View( _context.Bodegatripa.ToList());
        }

        // POST: ClasificacionTripas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ClasificacionTripaId,Detalle")] ClasificacionTripa clasificacionTripa)
        {
            if (ModelState.IsValid)
            {
                _context.Add(clasificacionTripa);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(clasificacionTripa);
        }

        // GET: ClasificacionTripas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var clasificacionTripa = await _context.ClasificacionTripa.SingleOrDefaultAsync(m => m.ClasificacionTripaId == id);
            if (clasificacionTripa == null)
            {
                return NotFound();
            }
            return View(clasificacionTripa);
        }

        // POST: ClasificacionTripas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ClasificacionTripaId,Detalle")] ClasificacionTripa clasificacionTripa)
        {
            if (id != clasificacionTripa.ClasificacionTripaId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(clasificacionTripa);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ClasificacionTripaExists(clasificacionTripa.ClasificacionTripaId))
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
            return View(clasificacionTripa);
        }

        // GET: ClasificacionTripas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var clasificacionTripa = await _context.ClasificacionTripa
                .SingleOrDefaultAsync(m => m.ClasificacionTripaId == id);
            if (clasificacionTripa == null)
            {
                return NotFound();
            }

            return View(clasificacionTripa);
        }

        // POST: ClasificacionTripas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var clasificacionTripa = await _context.ClasificacionTripa.SingleOrDefaultAsync(m => m.ClasificacionTripaId == id);
            _context.ClasificacionTripa.Remove(clasificacionTripa);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ClasificacionTripaExists(int id)
        {
            return _context.ClasificacionTripa.Any(e => e.ClasificacionTripaId == id);
        }
    }
}
