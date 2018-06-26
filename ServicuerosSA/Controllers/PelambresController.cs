using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ServicuerosSA.Data;
using ServicuerosSA.Models;

namespace ServicuerosSA.Controllers
{
    public class PelambresController : Controller
    {
        private readonly ApplicationDbContext _context;
        private PelambreModel clasePelambre;
        public PelambresController(ApplicationDbContext context)
        {
            _context = context;
            clasePelambre = new PelambreModel(context);
        }

        // GET: Pelambres
        public async Task<IActionResult> Index()
        {
            return View();
        }

        public List<ModeloEncabezadoFormula> ControladorImprimirEmcabezadoFormula(int id) {
            return clasePelambre.ModeloImprimirEncabezadoFormula(id);
        }
        public List<object[]> ControladorComponentesFormula(int id) {
            return clasePelambre.ModeloImprimirComponentes(id);
        }
        public List<object[]> ControladorListaIndex(int id)
        {
            return clasePelambre.ClaseIndexPelambre(id);
        }
        public List<object[]> ControladorListaPelambre()
        {
            return clasePelambre.ClaseListaPelambre();
        }
        public List<object[]> ControladorListaPelambrexTipoPiel(int tipopielId, int clasificacionId)
        {
            return clasePelambre.ClaseListaPelambrexTipoPiel(tipopielId, clasificacionId);
        }
        // GET: Pelambres/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pelambre = await _context.Pelambre
                .Include(p => p.Bodega1)
                .Include(p => p.Bombo)
                .Include(p => p.Formula)
                .SingleOrDefaultAsync(m => m.PelambreId == id);
            if (pelambre == null)
            {
                return NotFound();
            }

            return View(pelambre);
        }

        public List<IdentityError> ControladorActualizaClasificacionPelo(int bodegaid)
        {
            return clasePelambre.ActualizaClasificacionPelo(bodegaid);
        }

        public List<IdentityError> ControladorGuardarPelambre(DateTime fecha, string obsrvaciones, int idb, int bombo, int formula,  int personal, string codlote, int pesototal, int pieles)
        {
            return clasePelambre.ClaseGuardaPelambre(fecha, obsrvaciones,idb, bombo, formula,  personal, codlote, pesototal, pieles);
        }


        // GET: Pelambres/Create

        // GET: Pelambres/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pelambre = await _context.Pelambre.SingleOrDefaultAsync(m => m.PelambreId == id);
            if (pelambre == null)
            {
                return NotFound();
            }
            ViewData["Bodega1Id"] = new SelectList(_context.Bodega1, "Bodega1Id", "Bodega1Id", pelambre.Bodega1Id);
            ViewData["BomboId"] = new SelectList(_context.Bombo, "BomboId", "Peso", pelambre.BomboId);
            ViewData["FormulaId"] = new SelectList(_context.Set<Formula>(), "FormulaId", "Nombre", pelambre.FormulaId);
            return View(pelambre);
        }

        // POST: Pelambres/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PelambreId,Fecha,Observaciones,Bodega1Id,BomboId,FormulaId")] Pelambre pelambre)
        {
            if (id != pelambre.PelambreId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pelambre);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PelambreExists(pelambre.PelambreId))
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
            ViewData["Bodega1Id"] = new SelectList(_context.Bodega1, "Bodega1Id", "Bodega1Id", pelambre.Bodega1Id);
            ViewData["BomboId"] = new SelectList(_context.Bombo, "BomboId", "Peso", pelambre.BomboId);
            ViewData["FormulaId"] = new SelectList(_context.Set<Formula>(), "FormulaId", "Nombre", pelambre.FormulaId);
            return View(pelambre);
        }

        // GET: Pelambres/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pelambre = await _context.Pelambre
                .Include(p => p.Bodega1)
                .Include(p => p.Bombo)
                .Include(p => p.Formula)
                .SingleOrDefaultAsync(m => m.PelambreId == id);
            if (pelambre == null)
            {
                return NotFound();
            }

            return View(pelambre);
        }

        // POST: Pelambres/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var pelambre = await _context.Pelambre.SingleOrDefaultAsync(m => m.PelambreId == id);
            _context.Pelambre.Remove(pelambre);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PelambreExists(int id)
        {
            return _context.Pelambre.Any(e => e.PelambreId == id);
        }
    }
}
