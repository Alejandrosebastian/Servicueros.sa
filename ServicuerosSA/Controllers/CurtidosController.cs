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
    public class CurtidosController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CurtidosController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Curtidos
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Curtido.Include(c => c.Bombo).Include(c => c.ClasificacionTripa).Include(c => c.Formula).Include(c => c.Personal);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Curtidos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var curtido = await _context.Curtido
                .Include(c => c.Bombo)
                .Include(c => c.ClasificacionTripa)
                .Include(c => c.Formula)
                .Include(c => c.Personal)
                .SingleOrDefaultAsync(m => m.CurtidoId == id);
            if (curtido == null)
            {
                return NotFound();
            }

            return View(curtido);
        }

        // GET: Curtidos/Create
        public IActionResult Create()
        {
            ViewData["BomboId"] = new SelectList(_context.Bombo, "BomboId", "BomboId");
            ViewData["ClasificacionTripaId"] = new SelectList(_context.ClasificacionTripa, "ClasificacionTripaId", "Detalle");
            ViewData["FormulaId"] = new SelectList(_context.Formula, "FormulaId", "Nombre");
            ViewData["PersonalId"] = new SelectList(_context.Personal, "PersonalId", "Apellidos");
            return View();
        }

        // POST: Curtidos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CurtidoId,Fecha,Peso,Observaciones,NPieles,FormulaId,PersonalId,ClasificacionTripaId,BomboId")] Curtido curtido)
        {
            if (ModelState.IsValid)
            {
                _context.Add(curtido);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["BomboId"] = new SelectList(_context.Bombo, "BomboId", "BomboId", curtido.BomboId);
            ViewData["ClasificacionTripaId"] = new SelectList(_context.ClasificacionTripa, "ClasificacionTripaId", "Detalle", curtido.ClasificacionTripaId);
            ViewData["FormulaId"] = new SelectList(_context.Formula, "FormulaId", "Nombre", curtido.FormulaId);
            ViewData["PersonalId"] = new SelectList(_context.Personal, "PersonalId", "Apellidos", curtido.PersonalId);
            return View(curtido);
        }

        // GET: Curtidos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var curtido = await _context.Curtido.SingleOrDefaultAsync(m => m.CurtidoId == id);
            if (curtido == null)
            {
                return NotFound();
            }
            ViewData["BomboId"] = new SelectList(_context.Bombo, "BomboId", "BomboId", curtido.BomboId);
            ViewData["ClasificacionTripaId"] = new SelectList(_context.ClasificacionTripa, "ClasificacionTripaId", "Detalle", curtido.ClasificacionTripaId);
            ViewData["FormulaId"] = new SelectList(_context.Formula, "FormulaId", "Nombre", curtido.FormulaId);
            ViewData["PersonalId"] = new SelectList(_context.Personal, "PersonalId", "Apellidos", curtido.PersonalId);
            return View(curtido);
        }

        // POST: Curtidos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CurtidoId,Fecha,Peso,Observaciones,NPieles,FormulaId,PersonalId,ClasificacionTripaId,BomboId")] Curtido curtido)
        {
            if (id != curtido.CurtidoId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(curtido);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CurtidoExists(curtido.CurtidoId))
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
            ViewData["BomboId"] = new SelectList(_context.Bombo, "BomboId", "BomboId", curtido.BomboId);
            ViewData["ClasificacionTripaId"] = new SelectList(_context.ClasificacionTripa, "ClasificacionTripaId", "Detalle", curtido.ClasificacionTripaId);
            ViewData["FormulaId"] = new SelectList(_context.Formula, "FormulaId", "Nombre", curtido.FormulaId);
            ViewData["PersonalId"] = new SelectList(_context.Personal, "PersonalId", "Apellidos", curtido.PersonalId);
            return View(curtido);
        }

        // GET: Curtidos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var curtido = await _context.Curtido
                .Include(c => c.Bombo)
                .Include(c => c.ClasificacionTripa)
                .Include(c => c.Formula)
                .Include(c => c.Personal)
                .SingleOrDefaultAsync(m => m.CurtidoId == id);
            if (curtido == null)
            {
                return NotFound();
            }

            return View(curtido);
        }

        // POST: Curtidos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var curtido = await _context.Curtido.SingleOrDefaultAsync(m => m.CurtidoId == id);
            _context.Curtido.Remove(curtido);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CurtidoExists(int id)
        {
            return _context.Curtido.Any(e => e.CurtidoId == id);
        }
    }
}
