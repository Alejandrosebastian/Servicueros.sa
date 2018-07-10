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
    public class ComponentesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ComponentesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Componentes
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Componente.Include(c => c.Medida).Include(c => c.formula);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Componentes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var componente = await _context.Componente
                .Include(c => c.Medida)
                .Include(c => c.formula)
                .SingleOrDefaultAsync(m => m.ComponenteId == id);
            if (componente == null)
            {
                return NotFound();
            }

            return View(componente);
        }

        // GET: Componentes/Create
        public IActionResult Create()
        {
            ViewData["MedidaId"] = new SelectList(_context.Medida, "MedidaId", "Abreviatura");
            ViewData["FormulaId"] = new SelectList(_context.Formula, "FormulaId", "Nombre");
            return View();
        }

        // POST: Componentes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ComponenteId,Detalle,Porcentaje,Quimico,Tiempo,FormulaId,MedidaId")] Componente componente)
        {
            if (ModelState.IsValid)
            {
                _context.Add(componente);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["MedidaId"] = new SelectList(_context.Medida, "MedidaId", "Abreviatura", componente.MedidaId);
            ViewData["FormulaId"] = new SelectList(_context.Formula, "FormulaId", "Nombre", componente.FormulaId);
            return View(componente);
        }

        // GET: Componentes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var componente = await _context.Componente.SingleOrDefaultAsync(m => m.ComponenteId == id);
            if (componente == null)
            {
                return NotFound();
            }
            ViewData["MedidaId"] = new SelectList(_context.Medida, "MedidaId", "Abreviatura", componente.MedidaId);
            ViewData["FormulaId"] = new SelectList(_context.Formula, "FormulaId", "Nombre", componente.FormulaId);
            return View(componente);
        }

        // POST: Componentes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ComponenteId,Detalle,Porcentaje,Quimico,Tiempo,FormulaId,MedidaId")] Componente componente)
        {
            if (id != componente.ComponenteId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(componente);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ComponenteExists(componente.ComponenteId))
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
            ViewData["MedidaId"] = new SelectList(_context.Medida, "MedidaId", "Abreviatura", componente.MedidaId);
            ViewData["FormulaId"] = new SelectList(_context.Formula, "FormulaId", "Nombre", componente.FormulaId);
            return View(componente);
        }

        // GET: Componentes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var componente = await _context.Componente
                .Include(c => c.Medida)
                .Include(c => c.formula)
                .SingleOrDefaultAsync(m => m.ComponenteId == id);
            if (componente == null)
            {
                return NotFound();
            }

            return View(componente);
        }

        // POST: Componentes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var componente = await _context.Componente.SingleOrDefaultAsync(m => m.ComponenteId == id);
            _context.Componente.Remove(componente);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ComponenteExists(int id)
        {
            return _context.Componente.Any(e => e.ComponenteId == id);
        }
    }
}
