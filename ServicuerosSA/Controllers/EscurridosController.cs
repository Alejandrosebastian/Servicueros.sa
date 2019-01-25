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
    public class EscurridosController : Controller
    {
        private readonly ApplicationDbContext _context;
        private EscurridoModels listacurtido;

        public EscurridosController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Escurridos
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Escurrido.Include(e => e.Bombos);
            return View(await applicationDbContext.ToListAsync());
        }
        public List<Curtido> listacurtidoscbx()
        {
            return listacurtido.Modelolistacurtido();
        }
        // GET: Escurridos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var escurrido = await _context.Escurrido
                .Include(e => e.Bombos)
                .SingleOrDefaultAsync(m => m.EscurridoId == id);
            if (escurrido == null)
            {
                return NotFound();
            }

            return View(escurrido);
        }

        // GET: Escurridos/Create
        public IActionResult Create()
        {
            ViewData["BomboId"] = new SelectList(_context.Bombo, "BomboId", "BomboId");
            return View();
        }

        // POST: Escurridos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("EscurridoId,Cantidad,Fecha,CodigoLote,BomboId")] Escurrido escurrido)
        {
            if (ModelState.IsValid)
            {
                _context.Add(escurrido);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["BomboId"] = new SelectList(_context.Bombo, "BomboId", "BomboId", escurrido.BomboId);
            return View(escurrido);
        }

        // GET: Escurridos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var escurrido = await _context.Escurrido.SingleOrDefaultAsync(m => m.EscurridoId == id);
            if (escurrido == null)
            {
                return NotFound();
            }
            ViewData["BomboId"] = new SelectList(_context.Bombo, "BomboId", "BomboId", escurrido.BomboId);
            return View(escurrido);
        }

        // POST: Escurridos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("EscurridoId,Cantidad,Fecha,CodigoLote,BomboId")] Escurrido escurrido)
        {
            if (id != escurrido.EscurridoId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(escurrido);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EscurridoExists(escurrido.EscurridoId))
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
            ViewData["BomboId"] = new SelectList(_context.Bombo, "BomboId", "BomboId", escurrido.BomboId);
            return View(escurrido);
        }

        // GET: Escurridos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var escurrido = await _context.Escurrido
                .Include(e => e.Bombos)
                .SingleOrDefaultAsync(m => m.EscurridoId == id);
            if (escurrido == null)
            {
                return NotFound();
            }

            return View(escurrido);
        }

        // POST: Escurridos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var escurrido = await _context.Escurrido.SingleOrDefaultAsync(m => m.EscurridoId == id);
            _context.Escurrido.Remove(escurrido);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EscurridoExists(int id)
        {
            return _context.Escurrido.Any(e => e.EscurridoId == id);
        }
    }
}
