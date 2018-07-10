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
    public class LotesController : Controller
    {
        private readonly ApplicationDbContext _context;

        private LoteModel clasemodelListaLote;

        public LotesController(ApplicationDbContext context)
        {
            _context = context;
            clasemodelListaLote = new LoteModel(context);
        }

        public List<object[]> ContraladorListaLotes(int id)
        {
            return clasemodelListaLote.ClaseModelListaLotes(id);
        }

        public List<object[]> ContraladorUnLote(int codigoLote)
        {
            return clasemodelListaLote.ClaseSacarUnlote(codigoLote);
        }

        public List<IdentityError> ControladorComparaNumeroPieles(int coolo, int numeropieles)
        {
            return clasemodelListaLote.ModeloNumeroPielesLote(coolo, numeropieles);
        }
        public List<IdentityError> ControladorCodigoLote(string codigolote)
        {
            return clasemodelListaLote.ClaseModeloCodigoLote(codigolote);
        }
        // GET: Lotes
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = (from l in _context.Lote
                                       where l.estado == true
                                       select l).Include(l => l.Personal).Include(l => l.TipoPieles);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Lotes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lote = await _context.Lote
                
                .Include(l => l.Personal)
                .Include(l => l.TipoPieles)
                .SingleOrDefaultAsync(m => m.LoteId == id);
            if (lote == null)
            {
                return NotFound();
            }

            return View(lote);
        }

        // GET: Lotes/Create
        public IActionResult Create()
        {
          
            ViewData["PersonalId"] = new SelectList(_context.Personal, "PersonalId", "Apellidos");
            ViewData["TipoPielId"] = new SelectList(_context.TipoPiel, "TipoPielId", "Detalle");
            return View();
        }

        // POST: Lotes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("LoteId,Codigolote,Numerodepieles,Fechaingreso,PersonalId,TipoPielId,Observaciones")] Lote lote)
        {
            if (ModelState.IsValid)
            {
                lote.estado = true;
                _context.Add(lote);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
          
            ViewData["PersonalId"] = new SelectList(_context.Personal, "PersonalId", "Apellidos", lote.PersonalId);
            ViewData["TipoPielId"] = new SelectList(_context.TipoPiel, "TipoPielId", "Detalle", lote.TipoPielId);
            return View(lote);
        }

        // GET: Lotes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lote = await _context.Lote.SingleOrDefaultAsync(m => m.LoteId == id);
            if (lote == null)
            {
                return NotFound();
            }
           
            ViewData["PersonalId"] = new SelectList(_context.Personal, "PersonalId", "Apellidos", lote.PersonalId);
            ViewData["TipoPielId"] = new SelectList(_context.TipoPiel, "TipoPielId", "Detalle", lote.TipoPielId);
            return View(lote);
        }

        // POST: Lotes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("LoteId,Codigolote,Numerodepieles,Fechaingreso,PersonalId,TipoPielId,Observaciones")] Lote lote)
        {
            if (id != lote.LoteId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(lote);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LoteExists(lote.LoteId))
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
            
            ViewData["PersonalId"] = new SelectList(_context.Personal, "PersonalId", "Apellidos", lote.PersonalId);
            ViewData["TipoPielId"] = new SelectList(_context.TipoPiel, "TipoPielId", "Detalle", lote.TipoPielId);
            return View(lote);
        }

        // GET: Lotes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lote = await _context.Lote
                
                .Include(l => l.Personal)
                .Include(l => l.TipoPieles)
                .SingleOrDefaultAsync(m => m.LoteId == id);
            if (lote == null)
            {
                return NotFound();
            }

            return View(lote);
        }

        // POST: Lotes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var lote = await _context.Lote.SingleOrDefaultAsync(m => m.LoteId == id);
            _context.Lote.Remove(lote);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LoteExists(int id)
        {
            return _context.Lote.Any(e => e.LoteId == id);
        }
    }
}
