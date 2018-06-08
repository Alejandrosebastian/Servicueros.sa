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
    public class FormulasController : Controller
    {
        private readonly ApplicationDbContext _context;
        private FormulaModel claseFormulaModel;
        public FormulasController(ApplicationDbContext context)
        {
            _context = context;
            claseFormulaModel = new FormulaModel(context);
        }
        public List<Formula> ControladorListaFormulas()
        {
            return claseFormulaModel.ModelListaFormula();
        }
        // GET: Formulas
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Formula.Include(f => f.tipoPiel);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Formulas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var formula = await _context.Formula
                .Include(f => f.tipoPiel)
                .SingleOrDefaultAsync(m => m.FormulaId == id);
            if (formula == null)
            {
                return NotFound();
            }

            return View(formula);
        }

        // GET: Formulas/Create
        public IActionResult Create()
        {
            ViewData["TipoPielId"] = new SelectList(_context.TipoPiel, "TipoPielId", "Detalle");
            return View();
        }

        // POST: Formulas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("FormulaId,Nombre,Fecha_Creacion,TipoProceso,TipoPielId")] Formula formula)
        {
            if (ModelState.IsValid)
            {
                _context.Add(formula);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["TipoPielId"] = new SelectList(_context.TipoPiel, "TipoPielId", "Detalle", formula.TipoPielId);
            return View(formula);
        }

        // GET: Formulas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var formula = await _context.Formula.SingleOrDefaultAsync(m => m.FormulaId == id);
            if (formula == null)
            {
                return NotFound();
            }
            ViewData["TipoPielId"] = new SelectList(_context.TipoPiel, "TipoPielId", "Detalle", formula.TipoPielId);
            return View(formula);
        }

        // POST: Formulas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("FormulaId,Nombre,Fecha_Creacion,TipoProceso,TipoPielId")] Formula formula)
        {
            if (id != formula.FormulaId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(formula);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FormulaExists(formula.FormulaId))
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
            ViewData["TipoPielId"] = new SelectList(_context.TipoPiel, "TipoPielId", "Detalle", formula.TipoPielId);
            return View(formula);
        }

        // GET: Formulas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var formula = await _context.Formula
                .Include(f => f.tipoPiel)
                .SingleOrDefaultAsync(m => m.FormulaId == id);
            if (formula == null)
            {
                return NotFound();
            }

            return View(formula);
        }

        // POST: Formulas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var formula = await _context.Formula.SingleOrDefaultAsync(m => m.FormulaId == id);
            _context.Formula.Remove(formula);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FormulaExists(int id)
        {
            return _context.Formula.Any(e => e.FormulaId == id);
        }
    }
}
